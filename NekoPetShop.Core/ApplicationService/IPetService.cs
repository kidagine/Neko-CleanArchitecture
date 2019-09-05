using System;
using System.Collections.Generic;
using NekoPetShop.Core.Entity;

namespace NekoPetShop.Core.ApplicationService
{
    public enum SortType { Ascending, Descending };


    public interface IPetService
    {
        Pet NewPet(string name, AnimalType type, DateTime birthdate, DateTime soldDate, string color, Owner previousOwner, double price);
        Pet CreatePet(Pet pet);
        Pet UpdatePet(int id, Pet pet);
        Pet DeletePet(int id);
        List<Pet> GetPets();
        List<Pet> SearchPetsByType(AnimalType type);
        List<Pet> SortPetsByPrice(SortType type);
        List<Pet> GetCheapestPets();
    }
}
