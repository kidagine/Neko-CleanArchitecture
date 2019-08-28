using System;
using System.Collections.Generic;
using NekoPetShop.Core.Entity;

namespace NekoPetShop.Core.DomainService
{
    public interface IPetRepository
    {
        void CreatePet(string name, AnimalType type, DateTime birthdate, DateTime soldDate, string color, string previousOwner, double price);
        void RemovePet(int id);
        void UpdatePet(int id, string name, AnimalType type, DateTime birthdate, DateTime soldDate, string color, string previousOwner, double price);
        IEnumerable<Pet> GetPets();
    }
}
