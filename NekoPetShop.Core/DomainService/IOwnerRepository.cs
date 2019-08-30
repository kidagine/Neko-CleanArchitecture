using System.Collections.Generic;
using NekoPetShop.Core.Entity;

namespace NekoPetShop.Core.DomainService
{
    public interface IOwnerRepository
    {
        void CreateOwner(string firstName, string lastName, string address, string phoneNumber, string email);
        void UpdateOwner(int id, string firstName, string lastName, string address, string phoneNumber, string email);
        void DeleteOwner(int id);
        IEnumerable<Owner> GetOwners();
        Owner FindOwnerById(int id);
        void InitializeData();
    }
}
