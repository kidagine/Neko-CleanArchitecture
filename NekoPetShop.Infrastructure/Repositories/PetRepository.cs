using System;
using System.Linq;
using System.Collections.Generic;
using NekoPetShop.Core.Entity;
using NekoPetShop.Core.DomainService;

namespace NekoPetShop.Infrastructure.Repositories
{
    public class PetRepository : IPetRepository
    {
        public void CreatePet(string name, AnimalType type, DateTime birthdate, DateTime soldDate, string color, Owner previousOwner, double price)
        {
            List<Pet> updatedPetsList = FakeDB.ReadPetData().ToList();
            Pet petToAdd = new Pet() { Id = FakeDB.GetNextPetId(), Name = name, Type = type, Birthdate = birthdate, SoldDate = soldDate, Color = color, PreviousOwner = previousOwner, Price = price };
            updatedPetsList.Add(petToAdd);
            FakeDB.UpdatePetData(updatedPetsList);
        }

        public void UpdatePet(int id, string name, AnimalType type, DateTime birthdate, DateTime soldDate, string color, Owner previousOwner, double price)
        {
            List<Pet> updatedPetsList = FakeDB.ReadPetData().ToList();
            Pet petToUpdate = new Pet() { Id = id, Name = name, Type = type, Birthdate = birthdate, SoldDate = soldDate, Color = color, PreviousOwner = previousOwner, Price = price };
            foreach (Pet p in updatedPetsList)
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
            FakeDB.UpdatePetData(updatedPetsList);
        }

        public void DeletePet(int id)
        {
            List<Pet> updatedPetsList = FakeDB.ReadPetData().ToList();
            Pet petToRemove = null;
            foreach (Pet p in updatedPetsList)
            {
                if (p.Id == id)
                {
                    petToRemove = p;
                }
            }
            updatedPetsList.Remove(petToRemove);
            FakeDB.UpdatePetData(updatedPetsList);
        }

        public IEnumerable<Pet> GetPets()
        {
            return FakeDB.ReadPetData();
        }
    }
}
