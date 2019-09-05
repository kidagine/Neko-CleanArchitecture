using System.Linq;
using System.Collections.Generic;
using NekoPetShop.Core.Entity;
using NekoPetShop.Core.DomainService;

namespace NekoPetShop.Infrastructure.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        public void CreateOwner(Owner ownerToCreate)
        {
            List<Owner> updatedOwnersList = FakeDB.ReadOwnerData().ToList();
            ownerToCreate.Id = FakeDB.GetNextOwnerId();
            updatedOwnersList.Add(ownerToCreate);
            FakeDB.UpdateOwnerData(updatedOwnersList);
        }

        public void UpdateOwner(int id, Owner ownerToUpdate)
        {   
            List<Owner> updatedOwnersList = FakeDB.ReadOwnerData().ToList();
            foreach (Owner o in updatedOwnersList)
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
            FakeDB.UpdateOwnerData(updatedOwnersList);
        }

        public void DeleteOwner(int id)
        {
            List<Owner> updatedOwnersList = FakeDB.ReadOwnerData().ToList();
            Owner ownerToRemove = null;
            foreach (Owner o in updatedOwnersList)
            {
                if (o.Id == id)
                {
                    ownerToRemove = o;
                }
            }
            updatedOwnersList.Remove(ownerToRemove);
            FakeDB.UpdateOwnerData(updatedOwnersList);
        }

        public IEnumerable<Owner> GetOwners()
        {
            return FakeDB.ReadOwnerData();
        }

        public Owner FindOwnerById(int id)
        {
            List<Owner> ownersList = FakeDB.ReadOwnerData().ToList();
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
    }
}
