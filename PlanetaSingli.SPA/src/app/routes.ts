import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { UserListComponent } from './users/user-list/user-list.component';
import { LikesComponent } from './likes/likes.component';
import { AuthGuard } from './_guards/auth.guard';
import { UserDetailsComponent } from './users/user-details/user-details.component';
import { UserDetailsResolver } from './_resolvers/user-details.resolver';
import { UserListResolver } from './_resolvers/user-list.resolver';
import { UserEditComponent } from './users/user-edit/user-edit.component';
import { UserEditResolver } from './_resolvers/user-edit.resolver';
import { PreventUnsavedChangesGuard } from './_guards/prevent-unsaved-changes.guard';
import { LikesResolver } from './_resolvers/likes.resolver';
import { PostsComponent } from './posts/posts.component';

export const appRoutes: Routes = [
    {path: '', component: HomeComponent},
    {path: '', runGuardsAndResolvers: 'always', canActivate: [AuthGuard], children: [
        {path: 'uzytkownicy', component: UserListComponent, resolve: {users: UserListResolver}},
        {path: 'uzytkownicy/:id', component: UserDetailsComponent, resolve: {user: UserDetailsResolver}},
        {path: 'edycja', component: UserEditComponent, resolve: {user: UserEditResolver}, canDeactivate: [PreventUnsavedChangesGuard]},
        {path: 'polubienia', component: LikesComponent, resolve: {users: LikesResolver}},
        {path: 'posty', component: PostsComponent}
    ]},
    {path: '**', redirectTo: '', pathMatch: 'full'}
];