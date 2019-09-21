using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NekoPetShop.Core.Entity;
using NekoPetShop.Core.DomainService;

namespace NekoPetShop.Infrastructure.SQLData.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly NekoPetShopContext context;

        public OwnerRepository(NekoPetShopContext context)
        {
            this.context = context;
        }

        public Owner Create(Owner owner)
        {
            context.Add(owner);
            context.SaveChanges();
            return owner;
        }

        public Owner Update(int id, Owner owner)
        {
            var entityEntry = context.Update(owner);
            context.SaveChanges();
            return entityEntry.Entity;
        }

        public Owner Delete(int id)
        {
            var entityEntry = context.Remove(new Owner() { Id = id });
            context.SaveChanges();
            return entityEntry.Entity;
        }

        public Owner ReadById(int id)
        {
            return context.Owners.ToList().FirstOrDefault(owner => owner.Id == id);
        }

        public Owner ReadByIdIncludePets(int id)
        {
            return context.Owners.Include(p => p.Pets).FirstOrDefault(owner => owner.Id == id);
        }

        public IEnumerable<Owner> ReadAll()
        {
            return context.Owners.ToList();
        }
    }
}
