using System.Linq;
using System.Collections.Generic;
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

        public Owner CreateOwner(Owner owner)
        {
            context.Add(owner);
            context.SaveChanges();
            return owner;
        }

        public Owner DeleteOwner(int id)
        {
            var entityEntry = context.Remove(new Owner() { Id = id });
            context.SaveChanges();
            return entityEntry.Entity;
        }

        public Owner GetOwnerById(int id)
        {
            return context.owners.ToList().FirstOrDefault(owner => owner.Id == id);
        }

        public IEnumerable<Owner> GetOwners()
        {
            return context.owners.ToList();
        }

        public Owner UpdateOwner(int id, Owner owner)
        {
            var entityEntry = context.Update(owner);
            context.SaveChanges();
            return entityEntry.Entity;
        }
    }
}
