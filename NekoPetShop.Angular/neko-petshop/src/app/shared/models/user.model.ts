export class User {
  id: number;
  username: string;
  passwordHash: Uint8Array
  passwordSalt: Uint8Array
  isAdmin: boolean;
}