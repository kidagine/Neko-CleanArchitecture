using NekoPetShop.Core.Entity;
using System;
using System.Collections.Generic;

namespace NekoPetShop.Infrastructure
{
    public static class FakeDB
    {
        private static int id;
        private static List<Pet> petsList = new List<Pet>();

        public static void InitializeData()
        {
            Pet catPet1 = new Pet() { Id = id++, Name = "Charlie", Type = AnimalType.Cat, Birthdate = DateTime.Parse("01/04/2016"), SoldDate = DateTime.Parse("05/25/2016"), Color = "White", PreviousOwner = "Jack", Price = 50 };
            Pet catPet2 = new Pet() { Id = id++, Name = "Max", Type = AnimalType.Cat, Birthdate = DateTime.Parse("05/08/2018"), SoldDate = DateTime.Parse("08/25/2018"), Color = "Black", PreviousOwner = "Jack", Price = 55 };
            Pet catPet3 = new Pet() { Id = id++, Name = "Banana", Type = AnimalType.Cat, Birthdate = DateTime.Parse("02/13/2018"), SoldDate = DateTime.Parse("03/15/2018"), Color = "Orange", PreviousOwner = "Jack", Price = 29 };
            Pet catPet4 = new Pet() { Id = id++, Name = "Toby", Type = AnimalType.Cat, Birthdate = DateTime.Parse("07/11/2018"), SoldDate = DateTime.Parse("12/23/2019"), Color = "Orange", PreviousOwner = "Jack", Price = 100 };
            Pet catPet5 = new Pet() { Id = id++, Name = "Amigo", Type = AnimalType.Cat, Birthdate = DateTime.Parse("05/25/2019"), SoldDate = DateTime.Parse("08/22/2019"), Color = "Blue", PreviousOwner = "Jack", Price = 120 };
            Pet dogPet1 = new Pet() { Id = id++, Name = "Bingo", Type = AnimalType.Dog, Birthdate = DateTime.Parse("12/30/2018"), SoldDate = DateTime.Parse("05/02/2019"), Color = "Black", PreviousOwner = "Jack", Price = 45 };
            Pet dogPet2 = new Pet() { Id = id++, Name = "Biscuit", Type = AnimalType.Dog, Birthdate = DateTime.Parse("01/15/2017"), SoldDate = DateTime.Parse("10/09/2017"), Color = "Blond", PreviousOwner = "Jack", Price = 30 };
            Pet dogPet3 = new Pet() { Id = id++, Name = "Louis", Type = AnimalType.Dog, Birthdate = DateTime.Parse("12/03/2019"), SoldDate = DateTime.Parse("03/10/2019"), Color = "Brown", PreviousOwner = "Jack", Price = 90 };
            Pet dogPet4 = new Pet() { Id = id++, Name = "Frodo", Type = AnimalType.Dog, Birthdate = DateTime.Parse("06/28/2018"), SoldDate = DateTime.Parse("10/18/2018"), Color = "Brown", PreviousOwner = "Jack", Price = 50 };
            Pet dogPet5 = new Pet() { Id = id++, Name = "Gucci", Type = AnimalType.Dog, Birthdate = DateTime.Parse("03/15/2019"), SoldDate = DateTime.Parse("11/07/2019"), Color = "Blond", PreviousOwner = "Jack", Price = 30 };
            Pet dragonPet1 = new Pet() { Id = id++, Name = "Heidi", Type = AnimalType.Dragon, Birthdate = DateTime.Parse("10/22/2018"), SoldDate = DateTime.Parse("04/19/2019"), Color = "White", PreviousOwner = "Jack", Price = 150 };
            Pet dragonPet2 = new Pet() { Id = id++, Name = "Loki", Type = AnimalType.Dragon, Birthdate = DateTime.Parse("07/05/2019"), SoldDate = DateTime.Parse("12/02/2017"), Color = "Grey", PreviousOwner = "Jack", Price = 180 };
            Pet dragonPet3 = new Pet() { Id = id++, Name = "Otto", Type = AnimalType.Dragon, Birthdate = DateTime.Parse("10/09/2019"), SoldDate = DateTime.Parse("03/01/2020"), Color = "White", PreviousOwner = "Jack", Price = 200 };
            Pet dragonPet4 = new Pet() { Id = id++, Name = "Maxwell", Type = AnimalType.Dragon, Birthdate = DateTime.Parse("11/29/2018"), SoldDate = DateTime.Parse("07/30/2019"), Color = "Blond", PreviousOwner = "Jack", Price = 220 };
            Pet dragonPet5 = new Pet() { Id = id++, Name = "Mickey", Type = AnimalType.Dragon, Birthdate = DateTime.Parse("09/17/2018"), SoldDate = DateTime.Parse("09/11/2018"), Color = "Orange", PreviousOwner = "Jack", Price = 80 };
            Pet goatPet1 = new Pet() { Id = id++, Name = "Paco", Type = AnimalType.Goat, Birthdate = DateTime.Parse("02/24/2019"), SoldDate = DateTime.Parse("08/20/2019"), Color = "Black", PreviousOwner = "Jack", Price = 90 };
            Pet goatPet2 = new Pet() { Id = id++, Name = "Rex", Type = AnimalType.Goat, Birthdate = DateTime.Parse("08/10/2018"), SoldDate = DateTime.Parse("01/12/2018"), Color = "White", PreviousOwner = "Jack", Price = 40 };
            Pet goatPet3 = new Pet() { Id = id++, Name = "Tiki", Type = AnimalType.Goat, Birthdate = DateTime.Parse("10/05/2017"), SoldDate = DateTime.Parse("05/03/2018"), Color = "Grey", PreviousOwner = "Jack", Price = 65 };
            Pet goatPet4 = new Pet() { Id = id++, Name = "Bobo", Type = AnimalType.Goat, Birthdate = DateTime.Parse("05/12/2018"), SoldDate = DateTime.Parse("11/15/2019"), Color = "Orange", PreviousOwner = "Jack", Price = 35 };
            Pet goatPet5 = new Pet() { Id = id++, Name = "Potato", Type = AnimalType.Goat, Birthdate = DateTime.Parse("06/19/2019"), SoldDate = DateTime.Parse("05/29/2019"), Color = "Blond", PreviousOwner = "Jack", Price = 28 };
            petsList.Add(catPet1);
            petsList.Add(catPet2);
            petsList.Add(catPet3);
            petsList.Add(catPet4);
            petsList.Add(catPet5);
            petsList.Add(dogPet1);
            petsList.Add(dogPet2);
            petsList.Add(dogPet3);
            petsList.Add(dogPet4);
            petsList.Add(dogPet5);
            petsList.Add(dragonPet1);
            petsList.Add(dragonPet2);
            petsList.Add(dragonPet3);
            petsList.Add(dragonPet4);
            petsList.Add(dragonPet5);
            petsList.Add(goatPet1);
            petsList.Add(goatPet2);
            petsList.Add(goatPet3);
            petsList.Add(goatPet4);
            petsList.Add(goatPet5);
        }

        public static IEnumerable<Pet> ReadData()
        {
            return petsList;
        }
    }
}
