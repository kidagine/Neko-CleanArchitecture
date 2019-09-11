using System.Linq;
using System.Collections.Generic;
using NekoPetShop.Core.Entity;
using NekoPetShop.Core.DomainService;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace NekoPetShop.Infastructure.SQLData.Repositories
{
    class PetRepository : IPetRepository
    {
        private Context context;

        public PetRepository(Context context)
        {
            this.context = context;
        }
        public Pet CreatePet(Pet pet)
        {
            context.Add(pet);
            context.SaveChanges();
            return pet;
        }

        public Pet DeletePet(int id)
        {
            var entityEntry = context.Remove(new Pet() { Id = id });
            context.SaveChanges();
            return entityEntry.Entity;
        }

        public IEnumerable<Pet> GetPets()
        {
            return context.pets.ToList();
        }

        public Pet UpdatePet(int id, Pet pet)
        {
            var entityEntry = context.Update(pet);
            context.SaveChanges();
            return entityEntry.Entity;
        }
    }
}
