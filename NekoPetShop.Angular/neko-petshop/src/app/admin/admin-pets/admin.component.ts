import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup} from '@angular/forms';
import { Pet } from '../../pets/shared/pet.model';
import { PetService } from '../../pets/shared/pet.service';
import { Color } from '../../shared/models/color.model';
import { ColorService } from '../../shared/services/color.service';
import { Owner } from '../../shared/models/owner.model';
import { OwnerService } from '../../shared/services/owner.service';
import { PetColor } from 'src/app/shared/models/petColor.model';


@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss']
})
export class AdminComponent implements OnInit {
  pets: any[];
  colors: Color[];
  owners: Owner[];
  pet: Pet;
  color: Color;
  owner: Owner;
  colorsId: number[];
  petForm = new FormGroup({
    name: new FormControl(''),
    type: new FormControl(''),
    price: new FormControl(''),
    birthdate: new FormControl(''),
    soldDate: new FormControl(''),
    owner: new FormControl(''),
    petColors: new FormControl(''),
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
      this.petService.getAllPets()
      .subscribe(filteredList => { this.pets = filteredList.list; });
      this.colorService.getAllColors()
      .subscribe(colors => this.colors = colors);
      this.ownerService.getAllOwners()
      .subscribe(owners => this.owners = owners);
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
      this.colorsId = [1,2,3];
      const petFromFields = this.petForm.value;
      const pet = {
        name: petFromFields.name,
        type: petFromFields.type,
        price: petFromFields.price,
        birthday: petFromFields.birthday,
        soldDate: petFromFields.soldDate,
        owner: {id: petFromFields.owner},
        petColors: [{colorId: this.colorsId[0]}, {colorId: this.colorsId[1]}, {colorId: this.colorsId[2]}],
      };
      this.petService.addPet(pet as Pet)
        .subscribe(pets => this.pets.push(pets))
    }
    else if (this.currentEntity === 'colors')
    {
      const colorFromFields = this.colorForm.value;
      const color = {
        name: colorFromFields.name
      };
      this.colorService.addColor(color as Color)
        .subscribe(colors => this.colors.push(colors))
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
        .subscribe(owners => this.owners.push(owners))
    }
  }

  delete(product: any): void {
    if (this.currentEntity === 'pets')
    {
      if (confirm("Are you sure to delete " + product.name)) {
        this.pets = this.pets.filter(p => p !== product);
        this.petService.deletePet(product).subscribe();
      }
    }
    else if (this.currentEntity === 'colors')
    {
      if (confirm("Are you sure to delete " + product.name)) {
        this.colors = this.colors.filter(p => p !== product);
        this.colorService.deleteColor(product).subscribe();
      }
    }
    else if (this.currentEntity === 'owners')
    {
      if (confirm("Are you sure to delete " + product.name)) {
        this.owners = this.owners.filter(p => p !== product);
        this.ownerService.deleteOwner(product).subscribe();
      }
    }    
  }

  updatePet(id: number): void {
    const petFromFields = this.petForm.value;
    this.pet.name = petFromFields.name
    this.pet.type = petFromFields.type;
    this.pet.price = petFromFields.price;
    this.pet.birthday = petFromFields.birthday;
    this.pet.soldDate = petFromFields.soldDate;

    let updatedOwner = new Owner();
    updatedOwner.id = petFromFields.owner;
    this.pet.owner = updatedOwner;

    let pet = new Pet();
    let color = new Color();
    let updatedPetColors = [{petId: pet.id, pet: pet, colorId: this.colorsId[0], color: color},{petId: pet.id, pet: pet, colorId: 2, color: color}];
    this.pet.petColors = updatedPetColors;
    this.petService.updatePet(this.pet, id)
      .subscribe();
  }
  updateColor(id: number): void {
    const colorFromFields = this.colorForm.value;
    this.color.name = colorFromFields.name
    this.colorService.updateColor(this.color, id)
      .subscribe();
  }
  updateOwner(id: number): void {
    const ownerFromFields = this.ownerForm.value;
    this.owner.firstName = ownerFromFields.firstName
    this.owner.lastName = ownerFromFields.lastName
    this.owner.address = ownerFromFields.address
    this.owner.phoneNumber = ownerFromFields.phoneNumber
    this.owner.email = ownerFromFields.email
    this.ownerService.updateOwner(this.owner, id)
      .subscribe();
  }

  setSelectedPet(pet: Pet){
    this.pet = pet;
  }
  setSelectedColor(color: Color){
    this.color = color;
  }
  setSelectedOwner(owner: Owner){
    this.owner = owner;
  }

  ngOnInit() {
    this.getProducts(this.currentEntity);
  }

  changeColorArray(colorId: number){
    if (!this.colorsId)
    {
      this.colorsId = [];
    }
    if (this.colorsId.includes(colorId))
    {
      this.colorsId.splice(this.colorsId.indexOf(colorId),1);
    }
    else
    {
      this.colorsId.push(colorId);
    }
    console.debug(this.colorsId);
  }
}
