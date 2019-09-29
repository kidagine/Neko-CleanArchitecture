using System.Collections.Generic;
using NekoPetShop.Core.Entity;

namespace NekoPetShop.Core.ApplicationService
{
    public interface IOwnerService
    {
        Owner New(string firstName, string lastName, string address, string phoneNumber, string email);
        Owner Create(Owner owner);
        Owner Update(Owner owner);
        Owner Delete(int id);
        Owner ReadById(int id);
        List<Owner> ReadAll(Filter filter = null);
    }
}
