import { Component, OnInit } from '@angular/core';

import { Pet } from '../shared/pet.model';
import { PetService } from '../shared/pet.service';

@Component({
  selector: 'app-pet-list',
  templateUrl: './pet-list.component.html',
  styleUrls: ['./pet-list.component.scss']
})
export class PetListComponent implements OnInit {
  pets: Pet[];
  totalPages: number;
  currentPage: number;
  itemsPerPage: number = 6;

  constructor(private petService: PetService) { }

  getPets(currentPage: number): void {
    this.petService.getPets(currentPage, this.itemsPerPage, 1)
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

  ngOnInit() {
    this.getPets(1)
  }

}
