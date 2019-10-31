    using System;
using NekoPetShop.Core.Entity;

namespace NekoPetShop.Infrastructure.SQLData
{
    public class DBInitializer
    {
        public static void Seed(NekoPetShopContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            Owner owner1 = context.Owners.Add(new Owner() { FirstName = "Son", LastName = "Goku", Address = "King kai's 25", PhoneNumber = "6459124429", Email = "dragonballz@gmail.com" }).Entity;
            Owner owner4 = context.Owners.Add(new Owner() { FirstName = "Clarke", LastName = "Kent", Address = "Metropolis 89", PhoneNumber = "8424229058", Email = "notSuperman@hotmail.com" }).Entity;
            Owner owner3 = context.Owners.Add(new Owner() { FirstName = "Billidan", LastName = "Blurprage", Address = "Glaster bruf 23", PhoneNumber = "5628991924", Email = "illySuks@yahoo.com" }).Entity;
            Owner owner2 = context.Owners.Add(new Owner() { FirstName = "Illidan", LastName = "Stormrage", Address = "Thunder bluff 59", PhoneNumber = "5024121920", Email = "arthurSuks@yahoo.com" }).Entity;

            Pet catPet1 = context.Pets.Add(new Pet() { Name = "Charlie", Type = AnimalType.Cat, Birthdate = DateTime.Parse("01/04/2016"), SoldDate = DateTime.Parse("05/25/2016"), Owner = owner1, Price = 50 }).Entity;
            Pet catPet2 = context.Pets.Add(new Pet() { Name = "Max", Type = AnimalType.Cat, Birthdate = DateTime.Parse("05/08/2018"), SoldDate = DateTime.Parse("08/25/2018"), Owner = owner1, Price = 55 }).Entity;
            Pet dogPet1 = context.Pets.Add(new Pet() { Name = "Bingo", Type = AnimalType.Dog, Birthdate = DateTime.Parse("12/30/2018"), SoldDate = DateTime.Parse("05/02/2019"), Owner = owner2, Price = 45 }).Entity;
            Pet dogPet2 = context.Pets.Add(new Pet() { Name = "Biscuit", Type = AnimalType.Dog, Birthdate = DateTime.Parse("01/15/2017"), SoldDate = DateTime.Parse("10/09/2017"), Owner = owner2, Price = 30 }).Entity;
            Pet goatPet1 = context.Pets.Add(new Pet() { Name = "Paco", Type = AnimalType.Goat, Birthdate = DateTime.Parse("02/24/2019"), SoldDate = DateTime.Parse("08/20/2019"), Owner = owner3, Price = 90 }).Entity;
            Pet goatPet2 = context.Pets.Add(new Pet() { Name = "Rex", Type = AnimalType.Goat, Birthdate = DateTime.Parse("08/10/2018"), SoldDate = DateTime.Parse("01/12/2018"), Owner = owner3, Price = 40 }).Entity;
            Pet dragonPet1 = context.Pets.Add(new Pet() { Name = "Heidi", Type = AnimalType.Dragon, Birthdate = DateTime.Parse("10/22/2018"), SoldDate = DateTime.Parse("04/19/2019"), Owner = owner4, Price = 150 }).Entity;
            Pet dragonPet2 = context.Pets.Add(new Pet() { Name = "Loki", Type = AnimalType.Dragon, Birthdate = DateTime.Parse("07/05/2019"), SoldDate = DateTime.Parse("12/02/2017"), Owner = owner4, Price = 180 }).Entity;
			Pet PugPet1 = context.Pets.Add(new Pet() { Name = "Sam", Type = AnimalType.Pug, Birthdate = DateTime.Parse("10/22/2018"), SoldDate = DateTime.Parse("04/19/2019"), Owner = owner4, Price = 150 }).Entity;
			Pet PugPet2 = context.Pets.Add(new Pet() { Name = "Bibi", Type = AnimalType.Pug, Birthdate = DateTime.Parse("07/05/2019"), SoldDate = DateTime.Parse("12/02/2017"), Owner = owner4, Price = 180 }).Entity;
			Pet gundamPet1 = context.Pets.Add(new Pet() { Name = "Bandai", Type = AnimalType.Gundam, Birthdate = DateTime.Parse("10/22/2018"), SoldDate = DateTime.Parse("04/19/2019"), Owner = owner4, Price = 150 }).Entity;
			Pet gundamPet2 = context.Pets.Add(new Pet() { Name = "Oda", Type = AnimalType.Gundam, Birthdate = DateTime.Parse("07/05/2019"), SoldDate = DateTime.Parse("12/02/2017"), Owner = owner4, Price = 180 }).Entity;
			Pet broomPet1 = context.Pets.Add(new Pet() { Name = "Bob", Type = AnimalType.Broom, Birthdate = DateTime.Parse("10/22/2018"), SoldDate = DateTime.Parse("04/19/2019"), Owner = owner4, Price = 150 }).Entity;
			Pet broomPet2 = context.Pets.Add(new Pet() { Name = "Dexter", Type = AnimalType.Broom, Birthdate = DateTime.Parse("07/05/2019"), SoldDate = DateTime.Parse("12/02/2017"), Owner = owner4, Price = 180 }).Entity;


			Color colorRed = context.Colors.Add(new Color { Name = "Red" }).Entity;
            Color colorBlack = context.Colors.Add(new Color { Name = "Black" }).Entity;
            Color colorWhite = context.Colors.Add(new Color { Name = "White" }).Entity;

            owner1.Pets.Add(catPet1);
            owner1.Pets.Add(catPet2);
            owner2.Pets.Add(dogPet1);
            owner2.Pets.Add(dogPet2);
            owner3.Pets.Add(goatPet1);
            owner3.Pets.Add(goatPet2);
            owner4.Pets.Add(dragonPet1);
            owner4.Pets.Add(dragonPet2);

            context.PetColors.Add(new PetColor(){Pet = catPet1, Color = colorRed });

            context.SaveChanges();
        }
    }
}
