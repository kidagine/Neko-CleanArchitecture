import { Color } from 'src/app/colors/shared/color.model';
import { Pet } from 'src/app/pets/shared/pet.model';

export class PetColor {
  petId: number;
  pet: Pet;
  colorId: number;
  color: Color;
}