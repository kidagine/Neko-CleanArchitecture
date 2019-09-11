using NekoPetShop.Core.Entity;
using System.Collections.Generic;

namespace NekoPetShop.Core.ApplicationService
{
    public interface IOwnerService
    {
        Owner NewOwner(string firstName, string lastName, string address, string phoneNumber, string email);
        Owner CreateOwner(Owner owner);
        Owner UpdateOwner(int id, Owner owner);
        Owner DeleteOwner(int id);
        List<Owner> GetOwners();
        Owner FindOwnerById(int id);
    }
}
