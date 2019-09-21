using System.Collections.Generic;
using NekoPetShop.Core.Entity;

namespace NekoPetShop.Core.ApplicationService
{
    public interface IOwnerService
    {
        Owner New(string firstName, string lastName, string address, string phoneNumber, string email);
        Owner Create(Owner owner);
        Owner Update(int id, Owner owner);
        Owner Delete(int id);
        Owner ReadById(int id);
        Owner ReadByIdIncludePets(int id);
        List<Owner> ReadAll();
    }
}
