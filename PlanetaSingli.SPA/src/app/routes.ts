import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { UserListComponent } from './users/user-list/user-list.component';
import { LikesComponent } from './likes/likes.component';
import { MessagesComponent } from './messages/messages.component';
import { AuthGuard } from './_guards/auth.guard';
import { UserDetailsComponent } from './users/user-details/user-details.component';
import { UserDetailsResolver } from './_resolvers/user-details.resolver';
import { UserListResolver } from './_resolvers/user-list.resolver';

export const appRoutes: Routes = [
    {path: '', component: HomeComponent},
    {path: '', runGuardsAndResolvers: 'always', canActivate: [AuthGuard], children: [
        {path: 'uzytkownicy', component: UserListComponent, resolve: {users: UserListResolver}},
        {path: 'uzytkownicy/:id', component: UserDetailsComponent, resolve: {user: UserDetailsResolver}},
        {path: 'polubienia', component: LikesComponent},
        {path: 'wiadomosci', component: MessagesComponent}
    ]},
    {path: '**', redirectTo: '', pathMatch: 'full'}
];