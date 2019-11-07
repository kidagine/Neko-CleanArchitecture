using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using NekoPetShop.Core.Entity;
using NekoPetShop.Core.DomainService;

namespace NekoPetShop.Core.ApplicationService.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;


        public OwnerService(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        public Owner New(string firstName, string lastName, string address, string phoneNumber, string email)
        {
            Owner owner = new Owner() { FirstName = firstName, LastName = lastName, Address = address, PhoneNumber = phoneNumber, Email = email };
            return owner;
        }

        public Owner Create(Owner owner)
        {
            if (owner.Id != default)
            {
                throw new NotSupportedException($"The pet id should not be specified");
            }
            else if (string.IsNullOrEmpty(owner.FirstName))
            {
                throw new InvalidDataException("You need to specify the owner's first name.");
            }
            else if (string.IsNullOrEmpty(owner.LastName))
            {
                throw new InvalidDataException("You need to specify the owner's last name.");
            }
            return _ownerRepository.Create(owner);
        }

        public Owner Update(Owner owner)
        {
            if (string.IsNullOrEmpty(owner.FirstName))
            {
                throw new InvalidDataException("You need to specify the owner's first name.");
            }
            else if (string.IsNullOrEmpty(owner.LastName))
            {
                throw new InvalidDataException("You need to specify the owner's last name.");
            }
            return _ownerRepository.Update(owner);
        }

        public Owner Delete(int id)
        {
            Owner owner = _ownerRepository.ReadById(id);
            if (owner == null)
            {
                throw new NullReferenceException($"The owner with Id: {id} does not exist");
            }
            return _ownerRepository.Delete(id);
        }

        public Owner ReadById(int id)
        {
			if (id < 0)
			{
				throw new InvalidDataException($"The Id: {id} is of negative value");
			}
			return _ownerRepository.ReadById(id);
        }

        public List<Owner> ReadAll(Filter filter)
        {
            if (filter.CurrentPage < 0 || filter.ItemsPerPage < 0)
            {
                throw new InvalidDataException("Current Page and Items Page have to be zero or more");
            }
            return _ownerRepository.ReadAll(filter).ToList();
        }
    }
}
