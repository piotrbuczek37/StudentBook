import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { UserListComponent } from './users/user-list/user-list.component';
import { LikesComponent } from './likes/likes.component';
import { MessagesComponent } from './messages/messages.component';

export const appRoutes: Routes = [
    {path: 'home', component: HomeComponent},
    {path: 'uzytkownicy', component: UserListComponent},
    {path: 'polubienia', component: LikesComponent},
    {path: 'wiadomosci', component: MessagesComponent},
    {path: '**', redirectTo: 'home', pathMatch: 'full'}
];