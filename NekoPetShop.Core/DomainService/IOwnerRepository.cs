using System.Collections.Generic;
using NekoPetShop.Core.Entity;

namespace NekoPetShop.Core.DomainService
{
    public interface IOwnerRepository
    {
        Owner CreateOwner(Owner owner);
        Owner UpdateOwner(int id, Owner owner);
        Owner DeleteOwner(int id);
        IEnumerable<Owner> GetOwners();
        Owner FindOwnerById(int id);
    }
}
