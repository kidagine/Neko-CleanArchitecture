using System.Collections.Generic;
using NekoPetShop.Core.Entity;

namespace NekoPetShop.Core.DomainService
{
    public interface IOwnerRepository
    {
        Owner Create(Owner owner);
        Owner Update(int id, Owner owner);
        Owner Delete(int id);
        Owner ReadById(int id);
        Owner ReadByIdIncludePets(int id);
        IEnumerable<Owner> ReadAll();
    }
}
