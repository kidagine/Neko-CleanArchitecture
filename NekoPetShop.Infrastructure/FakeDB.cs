using System;
using System.Linq;
using System.Collections.Generic;
using NekoPetShop.Core.Entity;

namespace NekoPetShop.Infrastructure
{
    public static class FakeDB
    {
        private static int ownerId;
        private static int petId;
        private static IEnumerable<Pet> petsIenumarable;
        private static IEnumerable<Owner> ownersIenumarable;


        public static void InitializeData()
        {
            InitializeOwnerData();
            InitializePetData();
        }

        private static void InitializeOwnerData()
        {
            Owner owner1 = new Owner() { Id = ownerId++, FirstName = "Son", LastName = "Goku", Address = "King kai's 25", PhoneNumber = "6459124429", Email = "dragonballz@gmail.com" };
            Owner owner2 = new Owner() { Id = ownerId++, FirstName = "Illidan", LastName = "Stormrage", Address = "Thunder bluff 59", PhoneNumber = "5024121920", Email = "arthurSuks@yaho.com" };
            Owner owner3 = new Owner() { Id = ownerId++, FirstName = "Bart", LastName = "Simpson", Address = "Evergreen Terrace 13", PhoneNumber = "6824208534", Email = "eatMYSHORTS@gmail.com" };
            Owner owner4 = new Owner() { Id = ownerId++, FirstName = "Clarke", LastName = "Kent", Address = "Metropolis 89", PhoneNumber = "8424229058", Email = "notSuperman@hotmail.com" };
            List<Owner> ownersList = new List<Owner>();
            ownersList.Add(owner1);
            ownersList.Add(owner2);
            ownersList.Add(owner3);
            ownersList.Add(owner4);
            ownersIenumarable = ownersList;
        }

        private static void InitializePetData()
        {
            Pet catPet1 = new Pet() { Id = petId++, Name = "Charlie", Type = AnimalType.Cat, Birthdate = DateTime.Parse("01/04/2016"), SoldDate = DateTime.Parse("05/25/2016"), Color = "White", PreviousOwner = new Owner { Id = 1 }, Price = 50 };
            Pet catPet2 = new Pet() { Id = petId++, Name = "Max", Type = AnimalType.Cat, Birthdate = DateTime.Parse("05/08/2018"), SoldDate = DateTime.Parse("08/25/2018"), Color = "Black", PreviousOwner = new Owner { Id = 1 }, Price = 55 };
            Pet catPet3 = new Pet() { Id = petId++, Name = "Banana", Type = AnimalType.Cat, Birthdate = DateTime.Parse("02/13/2018"), SoldDate = DateTime.Parse("03/15/2018"), Color = "Orange", PreviousOwner = new Owner { Id = 1 }, Price = 29 };
            Pet catPet4 = new Pet() { Id = petId++, Name = "Toby", Type = AnimalType.Cat, Birthdate = DateTime.Parse("07/11/2018"), SoldDate = DateTime.Parse("12/23/2019"), Color = "Orange", PreviousOwner = new Owner { Id = 1 }, Price = 100 };
            Pet catPet5 = new Pet() { Id = petId++, Name = "Amigo", Type = AnimalType.Cat, Birthdate = DateTime.Parse("05/25/2019"), SoldDate = DateTime.Parse("08/22/2019"), Color = "Blue", PreviousOwner = new Owner { Id = 1 }, Price = 120 };
            Pet dogPet1 = new Pet() { Id = petId++, Name = "Bingo", Type = AnimalType.Dog, Birthdate = DateTime.Parse("12/30/2018"), SoldDate = DateTime.Parse("05/02/2019"), Color = "Black", PreviousOwner = new Owner { Id = 2 }, Price = 45 };
            Pet dogPet2 = new Pet() { Id = petId++, Name = "Biscuit", Type = AnimalType.Dog, Birthdate = DateTime.Parse("01/15/2017"), SoldDate = DateTime.Parse("10/09/2017"), Color = "Blond", PreviousOwner = new Owner { Id = 2 }, Price = 30 };
            Pet dogPet3 = new Pet() { Id = petId++, Name = "Louis", Type = AnimalType.Dog, Birthdate = DateTime.Parse("12/03/2019"), SoldDate = DateTime.Parse("03/10/2019"), Color = "Brown", PreviousOwner = new Owner { Id = 2 }, Price = 90 };
            Pet dogPet4 = new Pet() { Id = petId++, Name = "Frodo", Type = AnimalType.Dog, Birthdate = DateTime.Parse("06/28/2018"), SoldDate = DateTime.Parse("10/18/2018"), Color = "Brown", PreviousOwner = new Owner { Id = 2 }, Price = 50 };
            Pet dogPet5 = new Pet() { Id = petId++, Name = "Gucci", Type = AnimalType.Dog, Birthdate = DateTime.Parse("03/15/2019"), SoldDate = DateTime.Parse("11/07/2019"), Color = "Blond", PreviousOwner = new Owner { Id = 2 }, Price = 30 };
            Pet dragonPet1 = new Pet() { Id = petId++, Name = "Heidi", Type = AnimalType.Dragon, Birthdate = DateTime.Parse("10/22/2018"), SoldDate = DateTime.Parse("04/19/2019"), Color = "White", PreviousOwner = new Owner { Id = 3 }, Price = 150 };
            Pet dragonPet2 = new Pet() { Id = petId++, Name = "Loki", Type = AnimalType.Dragon, Birthdate = DateTime.Parse("07/05/2019"), SoldDate = DateTime.Parse("12/02/2017"), Color = "Grey", PreviousOwner = new Owner { Id = 3 }, Price = 180 };
            Pet dragonPet3 = new Pet() { Id = petId++, Name = "Otto", Type = AnimalType.Dragon, Birthdate = DateTime.Parse("10/09/2019"), SoldDate = DateTime.Parse("03/01/2020"), Color = "White", PreviousOwner = new Owner { Id = 3 }, Price = 200 };
            Pet dragonPet4 = new Pet() { Id = petId++, Name = "Maxwell", Type = AnimalType.Dragon, Birthdate = DateTime.Parse("11/29/2018"), SoldDate = DateTime.Parse("07/30/2019"), Color = "Blond", PreviousOwner = new Owner { Id = 3 }, Price = 220 };
            Pet dragonPet5 = new Pet() { Id = petId++, Name = "Mickey", Type = AnimalType.Dragon, Birthdate = DateTime.Parse("09/17/2018"), SoldDate = DateTime.Parse("09/11/2018"), Color = "Orange", PreviousOwner = new Owner { Id = 3 }, Price = 80 };
            Pet goatPet1 = new Pet() { Id = petId++, Name = "Paco", Type = AnimalType.Goat, Birthdate = DateTime.Parse("02/24/2019"), SoldDate = DateTime.Parse("08/20/2019"), Color = "Black", PreviousOwner = new Owner { Id = 4 }, Price = 90 };
            Pet goatPet2 = new Pet() { Id = petId++, Name = "Rex", Type = AnimalType.Goat, Birthdate = DateTime.Parse("08/10/2018"), SoldDate = DateTime.Parse("01/12/2018"), Color = "White", PreviousOwner = new Owner { Id = 4 }, Price = 40 };
            Pet goatPet3 = new Pet() { Id = petId++, Name = "Tiki", Type = AnimalType.Goat, Birthdate = DateTime.Parse("10/05/2017"), SoldDate = DateTime.Parse("05/03/2018"), Color = "Grey", PreviousOwner = new Owner { Id = 4 }, Price = 65 };
            Pet goatPet4 = new Pet() { Id = petId++, Name = "Bobo", Type = AnimalType.Goat, Birthdate = DateTime.Parse("05/12/2018"), SoldDate = DateTime.Parse("11/15/2019"), Color = "Orange", PreviousOwner = new Owner { Id = 4 }, Price = 35 };
            Pet goatPet5 = new Pet() { Id = petId++, Name = "Potato", Type = AnimalType.Goat, Birthdate = DateTime.Parse("06/19/2019"), SoldDate = DateTime.Parse("05/29/2019"), Color = "Blond", PreviousOwner = new Owner { Id = 4 }, Price = 28 };
            List<Pet> petsList = new List<Pet>();
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
            petsIenumarable = petsList;
        }

        public static IEnumerable<Owner> ReadOwnerData()
        {
            return ownersIenumarable;
        }

        public static IEnumerable<Pet> ReadPetData()
        {
            return petsIenumarable;
        }

        public static void UpdateOwnerData(List<Owner> updatedOwnersList)
        {
            ownersIenumarable = updatedOwnersList;
        }

        public static void UpdatePetData(List<Pet> updatedPetsList)
        {
            petsIenumarable = updatedPetsList;
        }

        public static int GetNextOwnerId()
        {
            return ownerId++;
        }

        public static int GetNextPetId()
        {
            return petId++;
        }
    }
}
