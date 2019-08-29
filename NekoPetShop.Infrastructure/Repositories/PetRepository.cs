using System;
using System.Collections.Generic;
using System.Linq;
using NekoPetShop.Core.DomainService;
using NekoPetShop.Core.Entity;

namespace NekoPetShop.Infrastructure.Repositories
{
    public class PetRepository : IPetRepository
    {
        static int id = 20;
        private List<Pet> petsList = new List<Pet>();

        public void CreatePet(string name, AnimalType type, DateTime birthdate, DateTime soldDate, string color, string previousOwner, double price)
        {
            Pet petToAdd = new Pet() {Id = id++, Name = name, Type = type, Birthdate = birthdate, SoldDate = soldDate, Color = color, PreviousOwner = previousOwner, Price = price };
            petsList.Add(petToAdd);
        }

        public void UpdatePet(int id, string name, AnimalType type, DateTime birthdate, DateTime soldDate, string color, string previousOwner, double price)
        {
            Pet petToUpdate = new Pet() { Id = id, Name = name, Type = type, Birthdate = birthdate, SoldDate = soldDate, Color = color, PreviousOwner = previousOwner, Price = price };
            foreach (Pet p in petsList)
            {
                if (p.Id == id)
                {
                    p.Name = petToUpdate.Name;
                    p.Type = petToUpdate.Type;
                    p.Birthdate = petToUpdate.Birthdate;
                    p.SoldDate = petToUpdate.SoldDate;
                    p.Color = petToUpdate.Color;
                    p.PreviousOwner = petToUpdate.PreviousOwner;
                    p.Price = petToUpdate.Price;
                }
            }
        }

        public void DeletePet(int id)
        {
            Pet petToRemove = null;
            foreach (Pet p in petsList)
            {
                if (p.Id == id)
                {
                    petToRemove = p;
                }
            }
            if (petToRemove != null)
            {
                petsList.Remove(petToRemove);
            }
        }

        public IEnumerable<Pet> ReadPets()
        {
            return petsList;
        }

        public void InitializeData()
        {
            FakeDB.InitializeData();
            petsList = FakeDB.ReadData().ToList();
        }
    }
}
