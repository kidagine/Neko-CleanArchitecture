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

            Pet catPet1 = context.Pets.Add(new Pet() { Name = "Charlie", Type = AnimalType.Cat, ProductDate = DateTime.Parse("01/04/2015"), Birthdate = DateTime.Parse("01/04/2011"), SoldDate = DateTime.Parse("05/25/2016"), Owner = owner1, Price = 210 }).Entity;
            Pet catPet2 = context.Pets.Add(new Pet() { Name = "Max", Type = AnimalType.Cat, ProductDate = DateTime.Parse("01/04/2014"), Birthdate = DateTime.Parse("05/08/2012"), SoldDate = DateTime.Parse("08/25/2018"), Owner = owner1, Price = 55 }).Entity;
			Pet catPet3 = context.Pets.Add(new Pet() { Name = "Narlie", Type = AnimalType.Cat, ProductDate = DateTime.Parse("01/04/2013"), Birthdate = DateTime.Parse("01/04/2014"), SoldDate = DateTime.Parse("05/25/2016"), Owner = owner1, Price = 30 }).Entity;
			Pet catPet4 = context.Pets.Add(new Pet() { Name = "Karl", Type = AnimalType.Cat, ProductDate = DateTime.Parse("01/04/2012"), Birthdate = DateTime.Parse("05/08/2015"), SoldDate = DateTime.Parse("08/25/2018"), Owner = owner1, Price = 15 }).Entity;
			Pet catPet5 = context.Pets.Add(new Pet() { Name = "Nolan", Type = AnimalType.Cat, ProductDate = DateTime.Parse("01/04/2011"), Birthdate = DateTime.Parse("01/04/2005"), SoldDate = DateTime.Parse("05/25/2016"), Owner = owner1, Price = 85 }).Entity;
			Pet catPet6 = context.Pets.Add(new Pet() { Name = "Fuzzy", Type = AnimalType.Cat, ProductDate = DateTime.Parse("01/04/2010"), Birthdate = DateTime.Parse("05/08/2014"), SoldDate = DateTime.Parse("08/25/2018"), Owner = owner1, Price = 125 }).Entity;
			Pet catPet7 = context.Pets.Add(new Pet() { Name = "Light", Type = AnimalType.Cat, ProductDate = DateTime.Parse("01/04/2009"), Birthdate = DateTime.Parse("01/04/2016"), SoldDate = DateTime.Parse("05/25/2016"), Owner = owner1, Price = 65 }).Entity;
			Pet catPet8 = context.Pets.Add(new Pet() { Name = "Banana", Type = AnimalType.Cat, ProductDate = DateTime.Parse("01/04/2008"), Birthdate = DateTime.Parse("05/08/2013"), SoldDate = DateTime.Parse("08/25/2018"), Owner = owner1, Price = 90 }).Entity;
			Pet dogPet1 = context.Pets.Add(new Pet() { Name = "Bingo", Type = AnimalType.Dog, ProductDate = DateTime.Parse("01/04/2007"), Birthdate = DateTime.Parse("12/30/2012"), SoldDate = DateTime.Parse("05/02/2019"), Owner = owner2, Price = 160 }).Entity;
            Pet dogPet2 = context.Pets.Add(new Pet() { Name = "Biscuit", Type = AnimalType.Dog, ProductDate = DateTime.Parse("01/04/2006"), Birthdate = DateTime.Parse("01/15/2010"), SoldDate = DateTime.Parse("10/09/2017"), Owner = owner2, Price = 30 }).Entity;
            Pet goatPet1 = context.Pets.Add(new Pet() { Name = "Paco", Type = AnimalType.Goat, ProductDate = DateTime.Parse("01/04/2005"), Birthdate = DateTime.Parse("02/24/2004"), SoldDate = DateTime.Parse("08/20/2019"), Owner = owner3, Price = 90 }).Entity;
            Pet goatPet2 = context.Pets.Add(new Pet() { Name = "Rex", Type = AnimalType.Goat, ProductDate = DateTime.Parse("01/04/2004"), Birthdate = DateTime.Parse("08/10/2006"), SoldDate = DateTime.Parse("01/12/2018"), Owner = owner3, Price = 40 }).Entity;
            Pet dragonPet1 = context.Pets.Add(new Pet() { Name = "Heidi", Type = AnimalType.Dragon, ProductDate = DateTime.Parse("01/04/2003"), Birthdate = DateTime.Parse("10/22/2015"), SoldDate = DateTime.Parse("04/19/2019"), Owner = owner4, Price = 150 }).Entity;
            Pet dragonPet2 = context.Pets.Add(new Pet() { Name = "Loki", Type = AnimalType.Dragon, ProductDate = DateTime.Parse("01/04/2002"), Birthdate = DateTime.Parse("07/05/2011"), SoldDate = DateTime.Parse("12/02/2017"), Owner = owner4, Price = 180 }).Entity;
			Pet pugPet1 = context.Pets.Add(new Pet() { Name = "Sam", Type = AnimalType.Pug, ProductDate = DateTime.Parse("01/04/2001"), Birthdate = DateTime.Parse("10/22/2001"), SoldDate = DateTime.Parse("04/19/2019"), Owner = owner4, Price = 150 }).Entity;
			Pet pugPet2 = context.Pets.Add(new Pet() { Name = "Bibi", Type = AnimalType.Pug, ProductDate = DateTime.Parse("01/04/2000"), Birthdate = DateTime.Parse("07/05/2003"), SoldDate = DateTime.Parse("12/02/2017"), Owner = owner4, Price = 180 }).Entity;

			Color colorRed = context.Colors.Add(new Color { Name = "Red" }).Entity;
            Color colorBlack = context.Colors.Add(new Color { Name = "Black" }).Entity;
            Color colorWhite = context.Colors.Add(new Color { Name = "White" }).Entity;

            owner1.Pets.Add(catPet1);
			owner1.Pets.Add(catPet2);
			owner1.Pets.Add(catPet3);
			owner1.Pets.Add(catPet4);
			owner1.Pets.Add(catPet5);
			owner1.Pets.Add(catPet6);
			owner1.Pets.Add(catPet7);
			owner1.Pets.Add(catPet8);
			owner1.Pets.Add(pugPet1);
			owner1.Pets.Add(pugPet2);
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
