using System.Linq;
using System.Collections.Generic;
using NekoPetShop.Core.Entity;
using NekoPetShop.Core.DomainService;
using Microsoft.EntityFrameworkCore;

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
            return context.pets;
        }

        public IEnumerable<Pet> GetPetsIncludeOwners()
        {
            return context.pets.Include(p => p.PreviousOwner);
        }

        public Pet UpdatePet(int id, Pet pet)
        {
            var entityEntry = context.Update(pet);
            context.SaveChanges();
            return entityEntry.Entity;
        }

        public Pet GetPetById(int id)
        {
            return context.pets.ToList().FirstOrDefault(pet => pet.Id == id);
        }

        public Pet GetPetByIdIncludeOwner(int id)
        {
            return context.pets.Include(p => p.PreviousOwner).FirstOrDefault(pet => pet.Id == id);
        }
    }
}
