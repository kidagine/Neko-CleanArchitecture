using System;
using System.Collections.Generic;
using NekoPetShop.Core.DomainService;
using NekoPetShop.Core.Entity;

namespace NekoPetShop.Infrastructure.Repositories
{
    public class PetRepository : IPetRepository
    {
        static int id = 1;
        private List<Pet> petsList = new List<Pet>();

        public void CreatePet(string name, AnimalType type, DateTime birthdate, DateTime soldDate, string color, string previousOwner, double price)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pet> GetPets()
        {
            throw new NotImplementedException();
        }

        public void RemovePet(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdatePet(int id, string name, AnimalType type, DateTime birthdate, DateTime soldDate, string color, string previousOwner, double price)
        {
            throw new NotImplementedException();
        }
    }
}
