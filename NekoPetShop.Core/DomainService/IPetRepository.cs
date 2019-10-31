using NekoPetShop.Core.Entity;
using NekoPetShop.Core.Entity.Filtering;

namespace NekoPetShop.Core.DomainService
{
    public interface IPetRepository
    {
        Pet Create(Pet pet);
        Pet Update(Pet pet);
        Pet Delete(int id);
        Pet ReadById(int id);
        FilteredList<Pet> ReadAll(Filter filter = null);
    }
}
