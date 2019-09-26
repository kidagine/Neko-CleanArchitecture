using System;
using System.Collections.Generic;
using NekoPetShop.Core.Entity;

namespace NekoPetShop.Core.ApplicationService
{
    public interface IPetService
    {
        Pet New(string name, AnimalType type, DateTime birthdate, DateTime soldDate, string color, Owner previousOwner, double price);
        Pet Create(Pet pet);
        Pet Update(int id, Pet pet);
        Pet Delete(int id);
        Pet ReadById(int id);
        List<Pet> ReadAll(Filter filter = null);
    }
}
