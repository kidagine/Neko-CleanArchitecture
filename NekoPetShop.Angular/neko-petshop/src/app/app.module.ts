import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule }    from '@angular/forms';
import { HttpClientModule }    from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavigationBarComponent } from './shared/navigation-bar/navigation-bar.component';
import { HomeComponent } from './home/home/home.component';
import { PetListComponent } from './pets/pet-list/pet-list.component';
import { FooterComponent } from './shared/footer/footer.component';
import { PetDetailComponent } from './pets/pet-detail/pet-detail.component';
import { AdminComponent } from './admin/admin-pets/admin.component';


@NgModule({
  declarations: [
    AppComponent,
    NavigationBarComponent,
    HomeComponent,
    PetListComponent,
    FooterComponent,
    PetDetailComponent,
    AdminComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
