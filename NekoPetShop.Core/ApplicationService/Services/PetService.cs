using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using NekoPetShop.Core.Entity;
using NekoPetShop.Core.DomainService;

namespace NekoPetShop.Core.ApplicationService.Services
{
    public class PetService : IPetService
    {
        private readonly IPetRepository petRepository;
        private readonly IOwnerRepository ownerRepository;


        public PetService(IPetRepository petRepository, IOwnerRepository ownerRepository)
        {
            this.petRepository = petRepository;
            this.ownerRepository = ownerRepository;
        }

        public Pet NewPet(string name, AnimalType type, DateTime birthdate, DateTime soldDate, string color, Owner previousOwner, double price)
        {
            Pet newPet = new Pet() { Name = name, Type = type, Birthdate = birthdate, SoldDate = soldDate, Color = color, PreviousOwner = previousOwner, Price = price };
            return newPet;
        }

        public Pet CreatePet(Pet pet)
        {
            ValidatePet(pet);
            return petRepository.CreatePet(pet);
        }

        public Pet UpdatePet(int id, Pet pet)
        {
            ValidatePet(pet);
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

        public List<Pet> GetPetsIncludeOwners()
        {
            return petRepository.GetPetsIncludeOwners().ToList();
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

        private void ValidatePet(Pet pet)
        {
            if (string.IsNullOrEmpty(pet.Name))
            {
                throw new InvalidDataException("You need to specify the pet's name.");
            }
            else if (pet.PreviousOwner != null)
            {
                if (ownerRepository.GetOwnerById(pet.PreviousOwner.Id) == null)
                {
                    throw new InvalidDataException($"Owner with ID: { pet.PreviousOwner.Id } does not exist.");
                }
            }
        }

        public Pet GetPetById(int id)
        {
            return petRepository.GetPetById(id);
        }

        public Pet GetPetByIdIncludeOwner(int id)
        {
            return petRepository.GetPetByIdIncludeOwner(id);
        }
    }
}
