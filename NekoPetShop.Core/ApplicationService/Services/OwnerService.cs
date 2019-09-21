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
            ValidateOwner(owner);
            return _ownerRepository.Create(owner);
        }

        public Owner Update(int id, Owner owner)
        {
            ValidateOwner(owner);
            return _ownerRepository.Update(id, owner);
        }

        public Owner Delete(int id)
        {
            return _ownerRepository.Delete(id);
        }

        public Owner ReadById(int id)
        {
            return _ownerRepository.ReadById(id);
        }

        public Owner ReadByIdIncludePets(int id)
        {
            return _ownerRepository.ReadByIdIncludePets(id);
        }

        public List<Owner> ReadAll()
        {
            return _ownerRepository.ReadAll().ToList();
        }

        private void ValidateOwner(Owner owner)
        {
            if (string.IsNullOrEmpty(owner.FirstName))
            {
                throw new InvalidDataException("You need to specify the owner's first name.");
            }
            else if (string.IsNullOrEmpty(owner.LastName))
            {
                throw new InvalidDataException("You need to specify the owner's last name.");
            }
            else if (string.IsNullOrEmpty(owner.Address))
            {
                throw new InvalidDataException("You need to specify the owner's address.");
            }
            else if (string.IsNullOrEmpty(owner.Email))
            {
                throw new InvalidDataException("You need to specify the owner's email.");
            }
            else if (string.IsNullOrEmpty(owner.PhoneNumber))
            {
                throw new InvalidDataException("You need to specify the owner's phone number.");
            }
        }
    }
}
