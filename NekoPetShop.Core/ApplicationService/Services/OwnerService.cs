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

        public void CreateOwner(string firstName, string lastName, string address, string phoneNumber, string email)
        {
            ownerRepository.CreateOwner(firstName, lastName, address, phoneNumber, email);
        }

        public void UpdateOwner(int id, string firstName, string lastName, string address, string phoneNumber, string email)
        {
            ownerRepository.UpdateOwner(id, firstName, lastName, address, phoneNumber, email);
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
