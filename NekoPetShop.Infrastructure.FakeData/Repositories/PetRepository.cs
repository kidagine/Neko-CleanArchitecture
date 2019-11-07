using System.Linq;
using System.Collections.Generic;
using NekoPetShop.Core.Entity;
using NekoPetShop.Core.DomainService;
using NekoPetShop.Core.Entity.Filtering;

namespace NekoPetShop.Infrastructure.FakeData.Repositories
{
    public class PetRepository : IPetRepository
    {
        public Pet Create(Pet petToCreate)
        {
            List<Pet> updatedPetsList = ReadAll().List.ToList();
			petToCreate.Id = FakeDB.GetNextPetId();
            petToCreate.Owner = FakeDB.ReadOwnerData().FirstOrDefault(o => o.Id == petToCreate.Owner.Id);
            updatedPetsList.Add(petToCreate);
            FakeDB.UpdatePetData(updatedPetsList);
            return petToCreate;
        }

        public Pet Update(Pet petToUpdate)
        {
            List<Pet> updatedPetsList = ReadAll().List.ToList();
			foreach (Pet p in updatedPetsList)
            {
                if (p.Id == petToUpdate.Id)
                {
                    p.Name = petToUpdate.Name;
                    p.Type = petToUpdate.Type;
                    p.Birthdate = petToUpdate.Birthdate;
                    p.SoldDate = petToUpdate.SoldDate;
                    p.Owner = petToUpdate.Owner = FakeDB.ReadOwnerData().FirstOrDefault(o => o.Id == petToUpdate.Owner.Id);
                    p.Price = petToUpdate.Price;
                }
            }
            FakeDB.UpdatePetData(updatedPetsList);
            return petToUpdate;
        }

        public Pet Delete(int id)
        {
            List<Pet> updatedPetsList = ReadAll().List.ToList();
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

        public FilteredList<Pet> ReadAll(Filter filter = null)
        {
			FilteredList<Pet> filteredList = new FilteredList<Pet>();
			foreach (Pet p in FakeDB.ReadPetData())
            {
                if (p.Owner == null) continue;
                p.Owner = FakeDB.ReadOwnerData().FirstOrDefault(o => o.Id == p.Owner.Id);
				filteredList.List.ToList().Add(p);
            }
			return filteredList;
		}

        public Pet ReadById(int id)
        {
            return FakeDB.ReadPetData().FirstOrDefault(pet => pet.Id == id);
        }
    }
}
