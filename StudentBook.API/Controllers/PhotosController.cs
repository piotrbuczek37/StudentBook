using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StudentBook.API.Data;
using StudentBook.API.Dtos;
using StudentBook.API.Helpers;
using StudentBook.API.Models;

namespace StudentBook.API.Controllers
{
    [Authorize]
    [Route("api/users/{userId}/photos")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly IOptions<CloudinarySettings> _cloudinaryConfig;
        private Cloudinary _cloudinary;
        public PhotosController(IUserRepository repository, IMapper mapper, IOptions<CloudinarySettings> cloudinaryConfig)
        {
            _cloudinaryConfig = cloudinaryConfig;
            _mapper = mapper;
            _repository = repository;

            Account account = new Account(
                _cloudinaryConfig.Value.CloudName,
                _cloudinaryConfig.Value.ApiKey,
                _cloudinaryConfig.Value.ApiSecret
            );

            _cloudinary = new Cloudinary(account);
        }

        [HttpPost]
        public async Task<IActionResult> AddPhotoForUser(int userId, [FromForm]PhotoForCreateDto photoForCreateDto)
        {
            if(userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            {
                return Unauthorized();
            }
            var userFromRepo = await _repository.GetUser(userId);

            var file = photoForCreateDto.File;
            var uploadResult = new ImageUploadResult();

            if(file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadParameters = new ImageUploadParams(){
                        File = new FileDescription(file.Name, stream),
                        Transformation = new Transformation().Width(500).Height(500).Crop("fill").Gravity("face")
                    };
                    uploadResult = _cloudinary.Upload(uploadParameters);
                }
            }

            photoForCreateDto.Url = uploadResult.Uri.ToString();
            photoForCreateDto.PublicId = uploadResult.PublicId;

            var photo = _mapper.Map<Photo>(photoForCreateDto);

            if(!userFromRepo.Photos.Any(p => p.IsMain))
            {
                photo.IsMain = true;
            }

            userFromRepo.Photos.Add(photo);

            if(await _repository.SaveAll())
            {
                var photoToReturn = _mapper.Map<PhotoForReturnDto>(photo);
                return CreatedAtRoute(nameof(GetPhoto), new {userId ,id = photo.Id}, photoToReturn);
            }
            return BadRequest("Błąd dodawania zdjęcia");
        }

        [HttpGet("{id}", Name = "GetPhoto")]
        public async Task<IActionResult> GetPhoto(int id)
        {
            var photoFromRepo = await _repository.GetPhoto(id);
            var photoForReturn = _mapper.Map<PhotoForReturnDto>(photoFromRepo);
            return Ok(photoForReturn);
        }

        [HttpPost("{id}/setMain")]
        public async Task<IActionResult> SetMainPhoto(int userId, int id)
        {
            if(userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            {
                return Unauthorized();
            }

            var user = await _repository.GetUser(userId);

            if (!user.Photos.Any(p => p.Id == id))
            {
                return Unauthorized();
            }

            var photoFromRepo = await _repository.GetPhoto(id);

            if(photoFromRepo.IsMain)
            {
                return BadRequest("To zdjęcię już jest ustawione jako profilowe");
            }

            var currentMainPhoto = await _repository.GetMainPhotoForUser(userId);
            currentMainPhoto.IsMain = false;
            photoFromRepo.IsMain = true;

            if(await _repository.SaveAll())
            {
                return NoContent();
            }
            return BadRequest("Nie udało się ustawić zdjęcia jako profilowe");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhoto(int userId, int id)
        {
            if(userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            {
                return Unauthorized();
            }

            var user = await _repository.GetUser(userId);

            if (!user.Photos.Any(p => p.Id == id))
            {
                return Unauthorized();
            }

            var photoFromRepo = await _repository.GetPhoto(id);

            if(photoFromRepo.IsMain)
            {
                return BadRequest("To zdjęcie jest ustawione jako profilowe i nie można go usunąć");
            }

            if(photoFromRepo.public_id != null)
            {
                var deleteParams = new DeletionParams(photoFromRepo.public_id);
                var result = _cloudinary.Destroy(deleteParams);

                if(result.Result == "ok")
                {
                    _repository.Delete(photoFromRepo);
                }
            } 
            else 
            {
                _repository.Delete(photoFromRepo);
            }

            if(await _repository.SaveAll())
            {
                return Ok();
            }
            return BadRequest("Nie udało się usunąć zdjęcia");
        }
    }
}