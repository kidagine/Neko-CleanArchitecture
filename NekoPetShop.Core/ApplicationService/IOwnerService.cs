using System.Collections.Generic;
using NekoPetShop.Core.Entity;

namespace NekoPetShop.Core.ApplicationService
{
    public interface IOwnerService
    {
        Owner NewOwner(string firstName, string lastName, string address, string phoneNumber, string email);
        Owner CreateOwner(Owner owner);
        Owner UpdateOwner(int id, Owner owner);
        Owner DeleteOwner(int id);
        List<Owner> GetOwners();
        Owner GetOwnerById(int id);
    }
}
