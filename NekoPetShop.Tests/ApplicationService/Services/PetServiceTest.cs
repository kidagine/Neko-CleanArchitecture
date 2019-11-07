using System;
using System.IO;
using Moq;
using Xunit;
using NekoPetShop.Core.DomainService;
using NekoPetShop.Core.ApplicationService.Services;
using NekoPetShop.Core.Entity;

namespace NekoPetShop.Tests.ApplicationService.Services
{
	public class PetServiceTest
	{
		[Fact]
		public void CreatePet_SpecifiedId_ThrowsNotSupportedException()
		{
			Mock<IPetRepository> petRepository = new Mock<IPetRepository>();
			PetService petService = new PetService(petRepository.Object);
			Pet pet = new Pet() { Id = 1 };

			Action actual = () => petService.Create(pet);

			Assert.Throws<NotSupportedException>(actual);
		}

		[Fact]
		public void CreatePet_NullName_ThrowsInvalidDataException()
		{
			Mock<IPetRepository> petRepository = new Mock<IPetRepository>();
			PetService petService = new PetService(petRepository.Object);
			Pet pet = new Pet() { Price = 1, Birthdate = DateTime.Now, SoldDate = DateTime.Now, Type = AnimalType.All };

			Action actual = () => petService.Create(pet);

			Assert.Throws<InvalidDataException>(actual);
		}

		[Fact]
		public void DeletePet_NonExistingId_ThrowsNullReferenceException()
		{
			Mock<IPetRepository> petRepository = new Mock<IPetRepository>();
			PetService petService = new PetService(petRepository.Object);

			Action actual = () => petService.Delete(1);

			Assert.Throws<NullReferenceException>(actual);
		}

		[Fact]
		public void ReadPetById_NegativeId_ThrowsNullReferenceException()
		{
			Mock<IPetRepository> petRepository = new Mock<IPetRepository>();
			PetService petService = new PetService(petRepository.Object);

			Action actual = () => petService.ReadById(-1);

			Assert.Throws<InvalidDataException>(actual);
		}

		[Fact]
		public void ReadAllColorsFiltered_NegativeCurrentPageOrNegativeItemsPerPage_ThrowsNullReferenceException()
		{
			Mock<IPetRepository> petRepository = new Mock<IPetRepository>();
			PetService petService = new PetService(petRepository.Object);
			Filter filter = new Filter() { CurrentPage = -1, ItemsPerPage = -1 };

			Action actual = () => petService.ReadAll(filter);

			Assert.Throws<InvalidDataException>(actual);
		}
	}
}
