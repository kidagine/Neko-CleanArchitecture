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
            List<Pet> updatedPetList = FakeDB.ReadPetData().ToList();
            Pet petToAdd = new Pet() { Id = FakeDB.GetNextPetId(), Name = name, Type = type, Birthdate = birthdate, SoldDate = soldDate, Color = color, PreviousOwner = previousOwner, Price = price };
            updatedPetList.Add(petToAdd);
            FakeDB.UpdatePetData(updatedPetList);
        }

        public void UpdatePet(int id, string name, AnimalType type, DateTime birthdate, DateTime soldDate, string color, Owner previousOwner, double price)
        {
            List<Pet> updatedPetList = FakeDB.ReadPetData().ToList();
            Pet petToUpdate = new Pet() { Id = id, Name = name, Type = type, Birthdate = birthdate, SoldDate = soldDate, Color = color, PreviousOwner = previousOwner, Price = price };
            foreach (Pet p in updatedPetList)
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
            FakeDB.UpdatePetData(updatedPetList);
        }

        public void DeletePet(int id)
        {
            List<Pet> updatedPetList = FakeDB.ReadPetData().ToList();
            Pet petToRemove = null;
            foreach (Pet p in updatedPetList)
            {
                if (p.Id == id)
                {
                    petToRemove = p;
                }
            }
            updatedPetList.Remove(petToRemove);
            FakeDB.UpdatePetData(updatedPetList);
        }

        public IEnumerable<Pet> ReadPets()
        {
            return FakeDB.ReadPetData();
        }
    }
}
