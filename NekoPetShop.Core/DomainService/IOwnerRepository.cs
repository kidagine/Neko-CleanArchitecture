using System.Collections.Generic;
using NekoPetShop.Core.Entity;

namespace NekoPetShop.Core.DomainService
{
    public interface IOwnerRepository
    {
        Owner Create(Owner owner);
        Owner Update(Owner owner);
        Owner Delete(int id);
        Owner ReadById(int id);
        IEnumerable<Owner> ReadAll(Filter filter = null);
    }
}
