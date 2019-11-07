using System;
using System.IO;
using NekoPetShop.Core.Entity;
using NekoPetShop.Core.DomainService;
using NekoPetShop.Core.Entity.Filtering;

namespace NekoPetShop.Core.ApplicationService.Services
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _petRepository;


        public PetService(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public Pet New(string name, AnimalType type, DateTime birthdate, DateTime soldDate, Owner previousOwner, double price)
        {
            Pet newPet = new Pet() { Name = name, Type = type, Birthdate = birthdate, SoldDate = soldDate, Owner = previousOwner, Price = price };
            return newPet;
        }

        public Pet Create(Pet pet)
        {
            if (pet.Id != default)
            {
                throw new NotSupportedException($"The pet id should not be specified");
            }
            if (string.IsNullOrEmpty(pet.Name))
            {
                throw new InvalidDataException("You need to specify the pet's name.");
            }
            return _petRepository.Create(pet);
        }

        public Pet Update(Pet pet)
        {
            if (_petRepository.ReadById(pet.Id) == null)
            {
                throw new NullReferenceException($"The pet with Id: {pet.Id} does not exist");
            }
            if (string.IsNullOrEmpty(pet.Name))
            {
                throw new InvalidDataException("You need to specify the pet's name.");
            }
            return _petRepository.Update(pet);
        }

        public Pet Delete(int id)
        {
            Pet pet = _petRepository.ReadById(id);
            if (pet == null)
            {
                throw new NullReferenceException($"The pet with Id: {id} does not exist");
            }
            return _petRepository.Delete(id);
        }

        public Pet ReadById(int id)
        {
			if (id < 0)
			{
				throw new InvalidDataException($"The Id: {id} is of negative value");
			}
			return _petRepository.ReadById(id);
        }

        public FilteredList<Pet> ReadAll(Filter filter = null)
        {
            if (filter.CurrentPage < 0 || filter.ItemsPerPage < 0)
            {
                throw new InvalidDataException("Current Page and Items Page have to be zero or more");
            }
            return _petRepository.ReadAll(filter);
        }
    }
}
