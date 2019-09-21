using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NekoPetShop.Core.Entity;
using NekoPetShop.Core.DomainService;

namespace NekoPetShop.Infrastructure.SQLData.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly NekoPetShopContext _context;

        public PetRepository(NekoPetShopContext context)
        {
            _context = context;
        }

        public Pet Create(Pet pet)
        {
            _context.Attach(pet).State = EntityState.Added;
            _context.SaveChanges();
            return pet;
        }

        public Pet Update(int id, Pet pet)
        {
            _context.Attach(pet).State = EntityState.Modified;
            _context.Entry(pet).Reference(p => p.Owner).IsModified = true;
            _context.SaveChanges();
            return pet;
        }

        public Pet Delete(int id)
        {
            var entityEntry = _context.Remove(new Pet() { Id = id });
            _context.SaveChanges();
            return entityEntry.Entity;
        }

        public Pet ReadById(int id)
        {
            return _context.Pets.ToList().FirstOrDefault(pet => pet.Id == id);
        }

        public Pet ReadByIdIncludeOwner(int id)
        {
            return _context.Pets.Include(p => p.Owner).FirstOrDefault(pet => pet.Id == id);
        }

        public IEnumerable<Pet> ReadAll(Filter filter = null)
        {
            if (filter.CurrentPage == 0 || filter.ItemsPerPage == 0)
            {
                return _context.Pets;
            }
            return _context.Pets.Skip((filter.CurrentPage - 1) * filter.ItemsPerPage).Take(filter.ItemsPerPage);
        }

        public IEnumerable<Pet> ReadAllIncludeOwners()
        {
            return _context.Pets.Include(p => p.Owner);
        }
    }
}
