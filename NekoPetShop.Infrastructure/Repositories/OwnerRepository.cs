using System.Linq;
using System.Collections.Generic;
using NekoPetShop.Core.Entity;
using NekoPetShop.Core.DomainService;

namespace NekoPetShop.Infrastructure.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        static int id = 20;
        private List<Owner> ownersList = new List<Owner>();


        public void CreateOwner(string firstName, string lastName, string address, string phoneNumber, string email)
        {
            Owner ownerToAdd = new Owner() { Id = id++, FirstName = firstName, LastName = lastName, Address = address, PhoneNumber = phoneNumber, Email = email };
            ownersList.Add(ownerToAdd);
        }

        public void UpdateOwner(int id, string firstName, string lastName, string address, string phoneNumber, string email)
        {
            Owner ownerToUpdate = new Owner() { Id = id, FirstName = firstName, LastName = lastName, Address = address, PhoneNumber = phoneNumber, Email = email };
            foreach (Owner o in ownersList)
            {
                if (o.Id == id)
                {
                    o.FirstName = ownerToUpdate.FirstName;
                    o.LastName = ownerToUpdate.LastName;
                    o.Address = ownerToUpdate.Address;
                    o.PhoneNumber = ownerToUpdate.Address;
                    o.Email = ownerToUpdate.Email;
                }
            }
        }

        public void DeleteOwner(int id)
        {
            Owner ownerToRemove = null;
            foreach (Owner o in ownersList)
            {
                if (o.Id == id)
                {
                    ownerToRemove = o;
                }
            }
            ownersList.Remove(ownerToRemove);
        }

        public IEnumerable<Owner> GetOwners()
        {
            return ownersList;
        }

        public Owner FindOwnerById(int id)
        {
            Owner ownerToReturn = null;
            foreach (Owner o in ownersList)
            {
                if (o.Id == id)
                {
                    ownerToReturn = o;
                }
            }
            return ownerToReturn;
        }

        public void InitializeData()
        {
            ownersList = FakeDB.ReadOwnerData().ToList();
        }
    }
}
