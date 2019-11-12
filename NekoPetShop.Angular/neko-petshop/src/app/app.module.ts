import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { NavigationBarComponent } from './shared/navigation-bar/navigation-bar.component';
import { HomeComponent } from './home/home/home.component';
import { PetListComponent } from './pets/pet-list/pet-list.component';
import { FooterComponent } from './shared/footer/footer.component';
import { PetDetailComponent } from './pets/pet-detail/pet-detail.component';
import { AdminComponent } from './admin/admin-pets/admin.component';
import { LogInComponent } from './shared/log-in/log-in.component';
import { AuthGuard } from './shared/auth-guard/auth-guard';
import { AuthenticationService } from './shared/services/authentication.service';
import { RegisterComponent } from './shared/register/register.component';


@NgModule({
  declarations: [
    AppComponent,
    NavigationBarComponent,
    HomeComponent,
    PetListComponent,
    FooterComponent,
    PetDetailComponent,
    AdminComponent,
    LogInComponent,
    RegisterComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [
    AuthGuard,
    AuthenticationService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
