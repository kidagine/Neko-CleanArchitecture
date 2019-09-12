using System.Linq;
using System.Collections.Generic;
using NekoPetShop.Core.Entity;
using NekoPetShop.Core.DomainService;

namespace NekoPetShop.Infrastructure.SQLData.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly NekoPetShopContext context;

        public PetRepository(NekoPetShopContext context)
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
