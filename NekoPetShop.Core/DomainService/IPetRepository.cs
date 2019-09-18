using System.Collections.Generic;
using NekoPetShop.Core.Entity;

namespace NekoPetShop.Core.DomainService
{
    public interface IPetRepository
    {
        Pet CreatePet(Pet pet);
        Pet UpdatePet(int id, Pet pet);
        Pet DeletePet(int id);
        IEnumerable<Pet> GetPets();
        IEnumerable<Pet> GetPetsIncludeOwners();
        Pet GetPetById(int id);
        Pet GetPetByIdIncludeOwner(int id);
    }
}
