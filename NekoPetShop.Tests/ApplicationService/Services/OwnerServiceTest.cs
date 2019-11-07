using System;
using System.IO;
using Moq;
using Xunit;
using NekoPetShop.Core.DomainService;
using NekoPetShop.Core.ApplicationService.Services;
using NekoPetShop.Core.Entity;

namespace NekoPetShop.Tests.ApplicationService.Services
{
	public class OwnerServiceTest
	{
		[Fact]
		public void CreateOwner_SpecifiedId_ThrowsNotSupportedException()
		{
			Mock<IOwnerRepository> ownerRepository = new Mock<IOwnerRepository>();
			OwnerService ownerService = new OwnerService(ownerRepository.Object);
			Owner owner = new Owner() { Id = 1 };

			Action actual = () => ownerService.Create(owner);

			Assert.Throws<NotSupportedException>(actual);
		}

		[Fact]
		public void CreateOwner_NullFirstName_ThrowsInvalidDataException()
		{
			Mock<IOwnerRepository> ownerRepository = new Mock<IOwnerRepository>();
			OwnerService ownerService = new OwnerService(ownerRepository.Object);
			Owner owner = new Owner() { LastName = "lastName", Address = "address", PhoneNumber = "phoneNumber", Email="email" };

			Action actual = () => ownerService.Create(owner);

			Assert.Throws<InvalidDataException>(actual);
		}

		[Fact]
		public void CreateNewOwner_NullLastName_ThrowsInvalidDataException()
		{
			Mock<IOwnerRepository> ownerRepository = new Mock<IOwnerRepository>();
			OwnerService ownerService = new OwnerService(ownerRepository.Object);
			Owner owner = new Owner() { FirstName = "firstName", Address = "address", PhoneNumber = "phoneNumber", Email = "email" };

			Action actual = () => ownerService.Create(owner);

			Assert.Throws<InvalidDataException>(actual);
		}

		[Fact]
		public void DeleteOwner_NonExistingId_ThrowsNullReferenceException()
		{
			Mock<IOwnerRepository> ownerRepository = new Mock<IOwnerRepository>();
			OwnerService ownerService = new OwnerService(ownerRepository.Object);

			Action actual = () => ownerService.Delete(1);

			Assert.Throws<NullReferenceException>(actual);
		}

		[Fact]
		public void ReadOwnerById_NegativeId_ThrowsNullReferenceException()
		{
			Mock<IOwnerRepository> ownerRepository = new Mock<IOwnerRepository>();
			OwnerService ownerService = new OwnerService(ownerRepository.Object);

			Action actual = () => ownerService.ReadById(-1);

			Assert.Throws<InvalidDataException>(actual);
		}

		[Fact]
		public void ReadAllOwnersFiltered_NegativeCurrentPageOrNegativeItemsPerPage_ThrowsNullReferenceException()
		{
			Mock<IOwnerRepository> ownerRepository = new Mock<IOwnerRepository>();
			OwnerService ownerService = new OwnerService(ownerRepository.Object);
			Filter filter = new Filter() { CurrentPage = -1, ItemsPerPage = -1 };

			Action actual = () => ownerService.ReadAll(filter);

			Assert.Throws<InvalidDataException>(actual);
		}
	}
}
