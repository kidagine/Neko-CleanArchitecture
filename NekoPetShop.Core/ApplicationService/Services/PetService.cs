using System;
using System.Collections.Generic;
using System.Linq;
using NekoPetShop.Core.DomainService;
using NekoPetShop.Core.Entity;

namespace NekoPetShop.Core.ApplicationService.Services
{
    public class PetService : IPetService
    {
        private readonly IPetRepository petRepository;

        public PetService(IPetRepository petRepository)
        {
            this.petRepository = petRepository;
        }

        public void CreatePet(string name, AnimalType type, DateTime birthdate, DateTime soldDate, string color, string previousOwner, double price)
        {
            throw new NotImplementedException();
        }

        public List<Pet> GetPets()
        {
            return petRepository.GetPets().ToList();
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
