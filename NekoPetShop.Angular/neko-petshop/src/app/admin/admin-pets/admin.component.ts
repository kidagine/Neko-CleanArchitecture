import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup} from '@angular/forms';
import { Pet } from '../../pets/shared/pet.model';
import { PetService } from '../../pets/shared/pet.service';
import { Color } from '../../shared/models/color.model';
import { ColorService } from '../../shared/services/color.service';
import { Owner } from '../../shared/models/owner.model';
import { OwnerService } from '../../shared/services/owner.service';


@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss']
})
export class AdminComponent implements OnInit {
  pets: Pet[];
  colors: Color[];
  owners: Owner[];
  petForm = new FormGroup({
    name: new FormControl(''),
    type: new FormControl(''),
    price: new FormControl('')
  });
  colorForm = new FormGroup({
    name: new FormControl(''),
  });
  ownerForm = new FormGroup({
    firstName: new FormControl(''),
    lastName: new FormControl(''),
    address: new FormControl(''),
    phoneNumber: new FormControl(''),
    email: new FormControl('')
  });
  currentEntity: string = 'pets';

  constructor(private petService: PetService, private colorService: ColorService, private ownerService: OwnerService) { }

  getProducts(currentEntity: string): void {
    this.currentEntity = currentEntity;
    if (this.currentEntity === 'pets')
    {
      this.petService.getPets(1, 17, 0, 0, 0)
      .subscribe(filteredList => {this.pets = filteredList.list});
    }
    else if (this.currentEntity === 'colors')
    {
      this.colorService.getAllColors()
      .subscribe(colors => this.colors = colors);
    }
    else{
      this.ownerService.getAllOwners()
      .subscribe(owners => this.owners = owners);
    }
  }

  addProduct(): void {
    if (this.currentEntity === 'pets')
    {
      const petFromFields = this.petForm.value;
      const pet = {
        name: petFromFields.name,
        type: petFromFields.type,
        price: petFromFields.price,
      };
      this.petService.addPet(pet as Pet)
        .subscribe()
    }
    else if (this.currentEntity === 'colors')
    {
      const colorFromFields = this.colorForm.value;
      const color = {
        name: colorFromFields.name
      };
      this.colorService.addColor(color as Color)
        .subscribe()
    }
    else{
      const ownerFromFields = this.ownerForm.value;
      const owner = {
        firstName: ownerFromFields.firstName,
        lastName: ownerFromFields.lastName,
        address: ownerFromFields.address,
        phoneNumber: ownerFromFields.phoneNumber,
        email: ownerFromFields.email
      };
      this.ownerService.addOwner(owner as Owner)
        .subscribe()
    }
  }

  delete(product: any): void {
    if (this.currentEntity === 'pets')
    {
      if (confirm("Are you sure to delete " + product.name)) {
        this.pets = this.pets.filter(p => p !== product);
        this.petService.deletePet(product).subscribe();}
    }
    else if (this.currentEntity === 'colors')
    {
      if (confirm("Are you sure to delete " + product.name)) {
        this.colors = this.colors.filter(p => p !== product);
        this.colorService.deleteColor(product).subscribe();}
    }
    else{
      if (confirm("Are you sure to delete " + product.name)) {
        this.pets = this.pets.filter(p => p !== product);
        this.petService.deletePet(product).subscribe();}
    }    
  }

  ngOnInit() {
    this.getProducts(this.currentEntity);
  }

}
