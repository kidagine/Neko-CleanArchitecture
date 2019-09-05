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

        public void CreateOwner(Owner owner)
        {
            ownerRepository.CreateOwner(owner);
        }

        public void UpdateOwner(Owner owner)
        {
            ownerRepository.UpdateOwner(owner);
        }

        public void DeleteOwner(int id)
        {
            ownerRepository.DeleteOwner(id);
        }

        public List<Owner> GetOwners()
        {
            return ownerRepository.GetOwners().ToList();
        }

        public Owner FindOwnerById(int id)
        {
            return ownerRepository.FindOwnerById(id);
        }
    }
}
