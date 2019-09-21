using System.Linq;
using System.Collections.Generic;
using NekoPetShop.Core.Entity;
using NekoPetShop.Core.DomainService;

namespace NekoPetShop.Infrastructure.FakeData.Repositories
{
    public class PetRepository : IPetRepository
    {
        public Pet CreatePet(Pet petToCreate)
        {
            List<Pet> updatedPetsList = GetPets().ToList();
            petToCreate.Id = FakeDB.GetNextPetId();
            petToCreate.Owner = FakeDB.ReadOwnerData().FirstOrDefault(o => o.Id == petToCreate.Owner.Id);
            updatedPetsList.Add(petToCreate);
            FakeDB.UpdatePetData(updatedPetsList);
            return petToCreate;
        }

        public Pet UpdatePet(int id, Pet petToUpdate)
        {
            List<Pet> updatedPetsList = GetPets().ToList();
            foreach (Pet p in updatedPetsList)
            {
                if (p.Id == id)
                {
                    p.Name = petToUpdate.Name;
                    p.Type = petToUpdate.Type;
                    p.Birthdate = petToUpdate.Birthdate;
                    p.SoldDate = petToUpdate.SoldDate;
                    p.Color = petToUpdate.Color;
                    p.Owner = petToUpdate.Owner = FakeDB.ReadOwnerData().FirstOrDefault(o => o.Id == petToUpdate.Owner.Id);
                    p.Price = petToUpdate.Price;
                }
            }
            FakeDB.UpdatePetData(updatedPetsList);
            return petToUpdate;
        }

        public Pet DeletePet(int id)
        {
            List<Pet> updatedPetsList = GetPets().ToList();
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
            return petToRemove;
        }

        public IEnumerable<Pet> GetPets()
        {
            List<Pet> petsList = new List<Pet>();
            foreach (Pet p in FakeDB.ReadPetData())
            {
                if (p.Owner == null) continue;
                p.Owner = FakeDB.ReadOwnerData().FirstOrDefault(o => o.Id == p.Owner.Id);
                petsList.Add(p);
            }
            return petsList;
        }

        public Pet GetPetById(int id)
        {
            return FakeDB.ReadPetData().FirstOrDefault(pet => pet.Id == id);
        }
    }
}
