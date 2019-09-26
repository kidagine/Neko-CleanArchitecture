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
            Pet pet = ReadById(id);
            _context.Attach(pet).State = EntityState.Deleted;
            _context.SaveChanges();
            return pet;
        }

        public Pet ReadById(int id)
        {
            return _context.Pets.Include(p => p.Owner).FirstOrDefault(pet => pet.Id == id);     
        }

        public IEnumerable<Pet> ReadAll(Filter filter = null)
        {
            IEnumerable<Pet> filteredPets;
            if (filter.CurrentPage != 0 && filter.ItemsPerPage != 0)
            {
                if (filter.OrderByType == OrderByType.Ascending)
                {
                    filteredPets = SortByType(filter).Include(p => p.Owner);
                }
                else
                {
                    filteredPets = SortByType(filter).Include(p => p.Owner).Reverse();
                }
            }
            else
            {
                filteredPets = _context.Pets.Include(p => p.Owner);
            }
            return filteredPets;
        }

        private IQueryable<Pet> SortByType(Filter filter)
        {
            switch (filter.SortType)
            {
                case SortType.Id:
                    return _context.Pets.Skip((filter.CurrentPage - 1) * filter.ItemsPerPage).Take(filter.ItemsPerPage).OrderBy(p => p.Id);
                case SortType.Name:
                    return _context.Pets.Skip((filter.CurrentPage - 1) * filter.ItemsPerPage).Take(filter.ItemsPerPage).OrderBy(p => p.Name);
                case SortType.Birthday:
                    return _context.Pets.Skip((filter.CurrentPage - 1) * filter.ItemsPerPage).Take(filter.ItemsPerPage).OrderBy(p => p.Birthdate);
                case SortType.SoldDate:
                    return _context.Pets.Skip((filter.CurrentPage - 1) * filter.ItemsPerPage).Take(filter.ItemsPerPage).OrderBy(p => p.SoldDate);
                case SortType.Color:
                    return _context.Pets.Skip((filter.CurrentPage - 1) * filter.ItemsPerPage).Take(filter.ItemsPerPage).OrderBy(p => p.Color);
                case SortType.Owner:
                    return _context.Pets.Skip((filter.CurrentPage - 1) * filter.ItemsPerPage).Take(filter.ItemsPerPage).OrderBy(p => p.Owner);
                case SortType.Price:
                    return _context.Pets.Skip((filter.CurrentPage - 1) * filter.ItemsPerPage).Take(filter.ItemsPerPage).OrderBy(p => p.Price);
                default:
                    return _context.Pets;
            }
        }
    }
}
