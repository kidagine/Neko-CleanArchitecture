import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home/home.component';
import { PetListComponent } from './pets/pet-list/pet-list.component';
import { PetDetailComponent }  from './pets/pet-detail/pet-detail.component';
import { AdminComponent }  from './admin/admin-pets/admin.component';
import { AuthGuard } from './shared/auth-guard/auth-guard';
import { LogInComponent } from './shared/log-in/log-in.component';
import { RegisterComponent } from './shared/register/register.component';


const routes: Routes = [
  { path: '', redirectTo: '/', pathMatch: 'full' },
  { path: '', component: HomeComponent },
  { path: 'pet/:id', component: PetDetailComponent },
  { path: 'pets', component: PetListComponent },
  { path: 'sign-in', component: LogInComponent},
  { path: 'register', component: RegisterComponent},
  { path: 'admin', component: AdminComponent, canActivate: [AuthGuard] },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }