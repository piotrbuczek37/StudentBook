using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlanetaSingli.API.Data;
using PlanetaSingli.API.Dtos;
using PlanetaSingli.API.Models;

namespace PlanetaSingli.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public PostsController(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IActionResult> ListPosts()
        {
            var posts = await _repository.GetPosts();
            var postsToReturn = _mapper.Map<IEnumerable<PostForListDto>>(posts);
            return Ok(posts);
        }

        [HttpPost]
        public async Task<IActionResult> AddPost([FromBody]PostForCreateDto postForCreateDto)
        {
            var content = postForCreateDto.Content;

            var post = _mapper.Map<Post>(postForCreateDto);
            _repository.Add(post);

            if(await _repository.SaveAll())
            {
                var postForList = _mapper.Map<PostForListDto>(post);
                return CreatedAtRoute(nameof(GetPost), new { id = post.Id}, postForList);
            }
            return BadRequest();
        }

        [HttpGet("{id}", Name = "GetPost")]
        public async Task<IActionResult> GetPost(int id)
        {
            var postFromRepo = await _repository.GetPost(id);
            var postForList = _mapper.Map<PostForListDto>(postFromRepo);
            return Ok(postForList);
        }
    }
}