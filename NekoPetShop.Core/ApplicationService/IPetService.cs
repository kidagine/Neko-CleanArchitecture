using System;
using System.Collections.Generic;
using NekoPetShop.Core.Entity;

namespace NekoPetShop.Core.ApplicationService
{
    public interface IPetService
    {
        void CreatePet(string name, AnimalType type, DateTime birthdate, DateTime soldDate, string color, Owner previousOwner, double price);
        void UpdatePet(int id, string name, AnimalType type, DateTime birthdate, DateTime soldDate, string color, Owner previousOwner, double price);
        void DeletePet(int id);
        List<Pet> GetPets();
        List<Pet> SearchPetsByType(AnimalType type);
        List<Pet> SortPetsByPrice(bool isAscending);
        List<Pet> GetCheapestPets();
        void InitializeData();
    }
}
