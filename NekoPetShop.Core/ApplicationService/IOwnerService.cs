using NekoPetShop.Core.Entity;
using System.Collections.Generic;

namespace NekoPetShop.Core.ApplicationService
{
    public interface IOwnerService
    {
        void CreateOwner(string firstName, string lastName, string address, string phoneNumber, string email);
        void UpdateOwner(int id, string firstName, string lastName, string address, string phoneNumber, string email);
        void DeleteOwner(int id);
        List<Owner> GetOwners();
        Owner FindOwnerById(int id);
    }
}
