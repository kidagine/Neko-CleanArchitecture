using System.IO;
using System.Linq;
using System.Collections.Generic;
using NekoPetShop.Core.Entity;
using NekoPetShop.Core.DomainService;

namespace NekoPetShop.Core.ApplicationService.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository ownerRepository;


        public OwnerService(IOwnerRepository ownerRepository)
        {
            this.ownerRepository = ownerRepository;
        }

        public Owner NewOwner(string firstName, string lastName, string address, string phoneNumber, string email)
        {
            Owner owner = new Owner() { FirstName = firstName, LastName = lastName, Address = address, PhoneNumber = phoneNumber, Email = email };
            return owner;
        }

        public Owner CreateOwner(Owner owner)
        {
            ValidateOwner(owner);
            return ownerRepository.CreateOwner(owner);
        }

        public Owner UpdateOwner(int id, Owner owner)
        {
            ValidateOwner(owner);
            return ownerRepository.UpdateOwner(id, owner);
        }

        public Owner DeleteOwner(int id)
        {
            return ownerRepository.DeleteOwner(id);
        }

        public List<Owner> GetOwners()
        {
            return ownerRepository.GetOwners().ToList();
        }

        public Owner FindOwnerById(int id)
        {
            return ownerRepository.FindOwnerById(id);
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
