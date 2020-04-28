import { Component, OnInit, Input } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from '../_models/user';
import { Post } from '../_models/post';
import { UserService } from '../_services/user.service';

@Component({
  selector: 'app-posts',
  templateUrl: './posts.component.html',
  styleUrls: ['./posts.component.css']
})
export class PostsComponent implements OnInit {

  posts: Post[];
  postForm: FormGroup;
  user: User;
  usernames: string[] = [];
  createdPost: Post;

  constructor(private userService: UserService, private authService: AuthService ,private alertify: AlertifyService, private fb: FormBuilder, private router: Router) { }

  ngOnInit() {
    this.createPostForm();
    this.getPosts();
  }

  getPosts(){
    this.userService.getPosts().subscribe(posts => {
      this.posts = posts;
      this.posts.forEach(post => {
        this.userService.getUser(post.userId).subscribe(user => {
          this.user = user;
          this.usernames.push(user.username);
        }, error => {
          this.alertify.error(error);
        });
      });
    }, error => {
      this.alertify.error(error);
    });
  }

  createPostForm(){
    this.postForm = this.fb.group({
      content: ['', Validators.required]
    });
  }

  sendPost(){
    if(this.postForm.valid){
    let userId = {
      userId: this.authService.decodedToken.nameid
    };
    this.createdPost = Object.assign({}, userId, this.postForm.value);
    console.log(this.createdPost);
    this.userService.sendPost(this.createdPost).subscribe(next => {
      this.alertify.success('Post został stworzony');
      this.getPosts();
    }, error => {
      this.alertify.error(error);
    });
    }
  }
}
