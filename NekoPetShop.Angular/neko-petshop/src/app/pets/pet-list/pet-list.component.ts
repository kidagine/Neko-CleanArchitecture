import { Component, OnInit } from '@angular/core';

import { Pet } from '../shared/pet.model';
import { PetService } from '../shared/pet.service';
import { Router, NavigationEnd } from '@angular/router';

@Component({
  selector: 'app-pet-list',
  templateUrl: './pet-list.component.html',
  styleUrls: ['./pet-list.component.scss']
})
export class PetListComponent implements OnInit {
  pets: Pet[];
  currentSort: string = "featured items";
  totalPages: number;
  currentPage: number = 1;
  animalType: number;
  sortType: number;
  orderByType: number;
  itemsPerPage: number = 6;

  constructor(private petService: PetService, private router: Router) { 
    this.router.routeReuseStrategy.shouldReuseRoute = function(){
      return false;
   }

   this.router.events.subscribe((evt) => {
      if (evt instanceof NavigationEnd) {
         this.router.navigated = false;
         window.scrollTo(0, 0);
      }
  });

}
  getPets(currentPage: number, animalType?: number, sortType?: number, orderByType?: number ): void {
    if (!currentPage)
    {
      currentPage = 1;
    }
    if (!animalType)
    {
      animalType = 0;
    }
    if (!sortType)
    {
      sortType = 0;
    }
    if (!orderByType)
    {
      orderByType = 0;
    }
    this.animalType = animalType;
    this.sortType = sortType;
    this.orderByType = orderByType
    this.currentPage = currentPage;
    this.petService.getPets(this.currentPage, this.itemsPerPage, this.animalType, this.sortType, this.orderByType)
    .subscribe(filteredList => {this.pets = filteredList.list; this.totalPages = filteredList.totalPages;});
  }

  add(name: string): void {
    name = name.trim();
    if (!name) { return; }
    this.petService.addPet({ name } as Pet)
      .subscribe(pet => {
        this.pets.push(pet);
      });
  }

  counter(i: number) {
    return new Array(i);
  }

  delete(pet: Pet): void {
    this.pets = this.pets.filter(p => p !== pet);
    this.petService.deletePet(pet).subscribe();
  }

  setCurrentSort(currentSort?: string){
    this.currentSort = currentSort;
  }

  ngOnInit() {
    this.getPets(1)
  }
}
