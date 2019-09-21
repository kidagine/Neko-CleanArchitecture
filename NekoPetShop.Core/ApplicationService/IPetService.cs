using System;
using System.Collections.Generic;
using NekoPetShop.Core.Entity;

namespace NekoPetShop.Core.ApplicationService
{
    public enum SortType { Ascending, Descending };


    public interface IPetService
    {
        Pet New(string name, AnimalType type, DateTime birthdate, DateTime soldDate, string color, Owner previousOwner, double price);
        Pet Create(Pet pet);
        Pet Update(int id, Pet pet);
        Pet Delete(int id);
        Pet ReadById(int id);
        Pet ReadByIdIncludeOwner(int id);
        List<Pet> ReadAll(Filter filter = null);
        List<Pet> ReadAllIncludeOwners();
        List<Pet> ReadByType(AnimalType type);
        List<Pet> ReadByPrice(SortType type);
        List<Pet> ReadCheapest();
    }
}
