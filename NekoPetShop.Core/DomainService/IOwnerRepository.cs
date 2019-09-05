using System.Collections.Generic;
using NekoPetShop.Core.Entity;

namespace NekoPetShop.Core.DomainService
{
    public interface IOwnerRepository
    {
        void CreateOwner(Owner owner);
        void UpdateOwner(int id, Owner owner);
        void DeleteOwner(int id);
        IEnumerable<Owner> GetOwners();
        Owner FindOwnerById(int id);
    }
}
