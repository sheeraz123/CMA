import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddMemberComponent } from './add-member/add-member.component';
import { MemberDetailsComponent } from './member-details/member-details.component';

const routes: Routes = [
  { path: "", redirectTo: "ViewMember", pathMatch: "full" },
  {path:"AddMember", component:AddMemberComponent},
 
  {path:"ViewMember/Edit/:id", component:AddMemberComponent},
//  {path:"AddMember", component:AddMemberComponent},
  {path:"ViewMember",component:MemberDetailsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
