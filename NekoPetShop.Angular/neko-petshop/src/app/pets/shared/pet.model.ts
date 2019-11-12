import { PetColor } from 'src/app/shared/models/petColor.model';
import { Owner } from 'src/app/shared/models/owner.model';

export class Pet {
  id: number;
  name: string;
  type?: string;
  age?: number;
  price?: number;
  birthday?: Date;
  soldDate?: Date;
  petColors?: PetColor[];
  owner?: Owner;
}