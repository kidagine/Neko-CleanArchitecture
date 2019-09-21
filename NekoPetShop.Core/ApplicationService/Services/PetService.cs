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
        private readonly IPetRepository _petRepository;


        public PetService(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public Pet New(string name, AnimalType type, DateTime birthdate, DateTime soldDate, string color, Owner previousOwner, double price)
        {
            Pet newPet = new Pet() { Name = name, Type = type, Birthdate = birthdate, SoldDate = soldDate, Color = color, Owner = previousOwner, Price = price };
            return newPet;
        }

        public Pet Create(Pet pet)
        {
            ValidatePet(pet);
            return _petRepository.Create(pet);
        }

        public Pet Update(int id, Pet pet)
        {
            ValidatePet(pet);
            return _petRepository.Update(id, pet);
        }

        public Pet Delete(int id)
        {
            return _petRepository.Delete(id);
        }

        public Pet ReadById(int id)
        {
            return _petRepository.ReadById(id);
        }

        public Pet ReadByIdIncludeOwner(int id)
        {
            return _petRepository.ReadByIdIncludeOwner(id);
        }

        public List<Pet> ReadAll(Filter filter = null)
        {
            if (filter.CurrentPage < 0 || filter.ItemsPerPage < 0)
            {
                throw new InvalidDataException("Current Page and Items Page have to be zero or more");
            }
            return _petRepository.ReadAll(filter).ToList();
        }

        public List<Pet> ReadAllIncludeOwners()
        {
            return _petRepository.ReadAllIncludeOwners().ToList();
        }

        public List<Pet> ReadByType(AnimalType type)
        {
            List<Pet> filteredPetsList = new List<Pet>();
            foreach (Pet p in _petRepository.ReadAll().ToList())
            {
                if (p.Type == type)
                {
                    filteredPetsList.Add(p);
                }
            }
            return filteredPetsList;
        }

        public List<Pet> ReadByPrice(SortType type)
        {
            if (type == SortType.Ascending)
            {
                return ReadAll().OrderBy(o => o.Price).ToList();
            }
            else
            {
                return ReadAll().OrderByDescending(o => o.Price).ToList();
            }
        }
        public List<Pet> ReadCheapest()
        {
            return ReadByPrice(SortType.Ascending).Take(5).ToList();
        }

        private void ValidatePet(Pet pet)
        {
            if (string.IsNullOrEmpty(pet.Name))
            {
                throw new InvalidDataException("You need to specify the pet's name.");
            }
        }
    }
}
