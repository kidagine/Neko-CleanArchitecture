using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NekoPetShop.Core.Entity;
using NekoPetShop.Core.DomainService;

namespace NekoPetShop.Infrastructure.SQLData.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly NekoPetShopContext _context;


        public OwnerRepository(NekoPetShopContext context)
        {
            _context = context;
        }

        public Owner Create(Owner owner)
        {
            _context.Attach(owner).State = EntityState.Added;
            _context.SaveChanges();
            return owner;
        }

        public Owner Update(int id, Owner owner)
        {
            _context.Attach(owner).State = EntityState.Modified;
            _context.Entry(owner).Reference(o => o.Pets).IsModified = true;
            _context.SaveChanges();
            return owner;
        }

        public Owner Delete(int id)
        {
            Owner owner = ReadById(id);
            _context.Attach(owner).State = EntityState.Deleted;
            _context.SaveChanges();
            return owner;
        }

        public Owner ReadById(int id)
        {
            return _context.Owners.Include(o => o.Pets).FirstOrDefault(owner => owner.Id == id); 
        }

        public IEnumerable<Owner> ReadAll(Filter filter = null)
        {
            IEnumerable<Owner> filteredOwners;
            if (filter.CurrentPage != 0 && filter.ItemsPerPage != 0)
            {
                if (filter.OrderByType == OrderByType.Ascending)
                {
                    filteredOwners = SortByType(filter).Include(o => o.Pets);
                }
                else
                {
                    filteredOwners = SortByType(filter).Include(o => o.Pets).Reverse();
                }
            }
            filteredOwners = _context.Owners.Include(o => o.Pets);
            return filteredOwners;
        }

        private IQueryable<Owner> SortByType(Filter filter)
        {
            switch (filter.SortType)
            {
                case SortType.Id:
                    return _context.Owners.Skip((filter.CurrentPage - 1) * filter.ItemsPerPage).Take(filter.ItemsPerPage).OrderBy(o => o.Id);
                case SortType.Name:
                    return _context.Owners.Skip((filter.CurrentPage - 1) * filter.ItemsPerPage).Take(filter.ItemsPerPage).OrderBy(o => o.FirstName);
                case SortType.Birthday:
                    return _context.Owners.Skip((filter.CurrentPage - 1) * filter.ItemsPerPage).Take(filter.ItemsPerPage).OrderBy(o => o.LastName);
                case SortType.SoldDate:
                    return _context.Owners.Skip((filter.CurrentPage - 1) * filter.ItemsPerPage).Take(filter.ItemsPerPage).OrderBy(o => o.Address);
                case SortType.Color:
                    return _context.Owners.Skip((filter.CurrentPage - 1) * filter.ItemsPerPage).Take(filter.ItemsPerPage).OrderBy(o => o.PhoneNumber);
                case SortType.Owner:
                    return _context.Owners.Skip((filter.CurrentPage - 1) * filter.ItemsPerPage).Take(filter.ItemsPerPage).OrderBy(o => o.Email);
                case SortType.Price:
                    return _context.Owners.Skip((filter.CurrentPage - 1) * filter.ItemsPerPage).Take(filter.ItemsPerPage).OrderBy(o => o.Pets);
                default:
                    return _context.Owners;
            }
        }
    }
}
