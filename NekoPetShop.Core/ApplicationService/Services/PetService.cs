using System;
using System.Linq;
using System.Collections.Generic;
using NekoPetShop.Core.Entity;
using NekoPetShop.Core.DomainService;

namespace NekoPetShop.Core.ApplicationService.Services
{
    public class PetService : IPetService
    {
        private readonly IPetRepository petRepository;


        public PetService(IPetRepository petRepository)
        {
            this.petRepository = petRepository;
        }

        public Pet NewPet(string name, AnimalType type, DateTime birthdate, DateTime soldDate, string color, Owner previousOwner, double price)
        {
            Pet newPet = new Pet() { Name = name, Type = type, Birthdate = birthdate, SoldDate = soldDate, Color = color, PreviousOwner = previousOwner, Price = price };
            return newPet;
        }

        public Pet CreatePet(Pet pet)
        {
            return petRepository.CreatePet(pet);
        }

        public Pet UpdatePet(int id, Pet pet)
        {
            return petRepository.UpdatePet(id, pet);
        }

        public Pet DeletePet(int id)
        {
            return petRepository.DeletePet(id);
        }

        public List<Pet> GetPets()
        {
            return petRepository.GetPets().ToList();
        }

        public List<Pet> SearchPetsByType(AnimalType type)
        {
            List<Pet> filteredPetsList = new List<Pet>();
            foreach (Pet p in petRepository.GetPets().ToList())
            {
                if (p.Type == type)
                {
                    filteredPetsList.Add(p);
                }
            }
            return filteredPetsList;
        }

        public List<Pet> SortPetsByPrice(SortType type)
        {
            if (type == SortType.Ascending)
            {
                return GetPets().OrderBy(o => o.Price).ToList();
            }
            else
            {
                return GetPets().OrderByDescending(o => o.Price).ToList();
            }
        }
        public List<Pet> GetCheapestPets()
        {
            return SortPetsByPrice(SortType.Ascending).Take(5).ToList();
        }
    }
}
