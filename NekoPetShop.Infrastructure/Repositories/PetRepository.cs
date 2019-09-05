using System.Linq;
using System.Collections.Generic;
using NekoPetShop.Core.Entity;
using NekoPetShop.Core.DomainService;

namespace NekoPetShop.Infrastructure.Repositories
{
    public class PetRepository : IPetRepository
    {
        public Pet CreatePet(Pet petToCreate)
        {
            List<Pet> updatedPetsList = FakeDB.ReadPetData().ToList();
            petToCreate.Id = FakeDB.GetNextPetId();
            updatedPetsList.Add(petToCreate);
            FakeDB.UpdatePetData(updatedPetsList);
            return petToCreate;
        }

        public Pet UpdatePet(Pet petToUpdate)
        {
            List<Pet> updatedPetsList = FakeDB.ReadPetData().ToList();
            foreach (Pet p in updatedPetsList)
            {
                if (p.Id == petToUpdate.Id)
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
            return petToUpdate;
        }

        public Pet DeletePet(int id)
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
            return petToRemove;
        }

        public IEnumerable<Pet> GetPets()
        {
            return FakeDB.ReadPetData();
        }
    }
}
