using System.Collections.Generic;
using NekoPetShop.Core.Entity;

namespace NekoPetShop.Core.DomainService
{
    public interface IPetRepository
    {
        Pet Create(Pet pet);
        Pet Update(Pet pet);
        Pet Delete(int id);
        Pet ReadById(int id);
        IEnumerable<Pet> ReadAll(Filter filter = null);
    }
}
