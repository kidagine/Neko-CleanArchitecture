import { Component, OnInit } from '@angular/core';
import { Pet } from '../../pets/shared/pet.model';
import { PetService } from '../../pets/shared/pet.service';


@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss']
})
export class AdminComponent implements OnInit {
  pets: Pet[];

  constructor(private petService: PetService) { }

  getPets(): void {
    this.petService.getPets()
    .subscribe(pets => this.pets = pets);
  }

  add(name: string): void {
    name = name.trim();
    if (!name) { return; }
    this.petService.addPet({ name } as Pet)
      .subscribe(pet => {
        this.pets.push(pet);
      });
  }

  delete(pet: Pet): void {
    if (confirm("Are you sure to delete " + pet.name)) {
      this.pets = this.pets.filter(p => p !== pet);
      this.petService.deletePet(pet).subscribe();
    }    
  }

  ngOnInit() {
    this.getPets()
  }

}
