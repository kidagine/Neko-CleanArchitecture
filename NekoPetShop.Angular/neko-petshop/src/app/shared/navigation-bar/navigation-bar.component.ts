import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../services/authentication.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navigation-bar',
  templateUrl: './navigation-bar.component.html',
  styleUrls: ['./navigation-bar.component.scss']
})
export class NavigationBarComponent implements OnInit {
  username: string
  hideNavigationItems() {
    var x = document.getElementById("myTopnav");
    if (x.className === "topnav") {
      x.className += " responsive";
    } else {
      x.className = "topnav";
    }
  }
  constructor(private router: Router, private authenticationService: AuthenticationService) { }

  ngOnInit() {
    if (this.authenticationService.getToken())
    {
      this.username = this.authenticationService.getUsername()
    }
  }

  logOut() {
    this.authenticationService.logout();
    window.location.reload();
  }

}
