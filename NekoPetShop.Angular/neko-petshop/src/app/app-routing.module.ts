import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home/home.component';
import { PetListComponent } from './pets/pet-list/pet-list.component';
import { PetDetailComponent }  from './pets/pet-detail/pet-detail.component';
import { AdminComponent }  from './admin/admin-pets/admin.component';


const routes: Routes = [
  { path: '', redirectTo: '/', pathMatch: 'full' },
  { path: '', component: HomeComponent },
  { path: 'pet/:id', component: PetDetailComponent },
  { path: 'pets', component: PetListComponent },
  { path: 'admin', component: AdminComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }