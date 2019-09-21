using System.Collections.Generic;
using NekoPetShop.Core.Entity;

namespace NekoPetShop.Core.DomainService
{
    public interface IPetRepository
    {
        Pet Create(Pet pet);
        Pet Update(int id, Pet pet);
        Pet Delete(int id);
        Pet ReadById(int id);
        Pet ReadByIdIncludeOwner(int id);
        IEnumerable<Pet> ReadAll(Filter filter = null);
        IEnumerable<Pet> ReadAllIncludeOwners();
    }
}
