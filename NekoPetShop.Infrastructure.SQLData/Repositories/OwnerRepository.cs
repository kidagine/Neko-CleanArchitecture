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

        public IEnumerable<Owner> ReadAll(Filter filter)
        {
            IEnumerable<Owner> filteredOwners;
            if (filter.CurrentPage != 0 && filter.ItemsPerPage != 0)
            {
                if (filter.OrderByType == OrderByType.Ascending)
                {
                    return _context.Owners.Include(o => o.Pets).Skip((filter.CurrentPage - 1) * filter.ItemsPerPage).Take(filter.ItemsPerPage).OrderBy(c => c.Id);
                }
                else
                {
                    return _context.Owners.Include(o => o.Pets).Skip((filter.CurrentPage - 1) * filter.ItemsPerPage).Take(filter.ItemsPerPage).OrderBy(c => c.Id).Reverse();
                }
            }
            else
            {
                filteredOwners = _context.Owners.Include(o => o.Pets);
            }
            return filteredOwners;
        }
    }
}
