import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ListsComponent } from './lists/lists.component';
import { MembersDetailComponent } from './members/members-detail/members-detail.component';
import { MembersListComponent } from './members/members-list/members-list.component';
import { MessagesComponent } from './messages/messages.component';
import { AuthGuard } from './_guards/auth.guard';

const routes: Routes = [//here we adding routes to our components
{path:'',component:HomeComponent},//empty '' specifying default page(home)(localhost:4200)

{//CREATING ARRAY OF ROUTES
    path:'',
    runGuardsAndResolvers:'always',
    canActivate:[AuthGuard],
    children:[
{path:'members',component:MembersListComponent ,canActivate:[AuthGuard]},//localhost:4200/members
{path:'members/:id',component:MembersDetailComponent},//localhost:4200/members/5   the-":id" is parametr indicator
{path:'lists',component:ListsComponent},//localhost:4200/lists
{path:'messages',component:MessagesComponent},//localhost:4200:messages
] 
},
{path:'**',component:HomeComponent,pathMatch:'full'}//localhost:4200/**  if user types rout that not defined in our routes array
                                  //he will be redirected to our home page; 
                                  //pathMatch:'full' -->it means that if user typed halfly matched URL 
                                  //it won't work and user will be redirect to home page
                                  //because we specified that Url match must be fully matched

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
