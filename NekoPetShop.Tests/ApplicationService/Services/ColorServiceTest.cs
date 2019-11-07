using System;
using System.IO;
using Moq;
using Xunit;
using NekoPetShop.Core.DomainService;
using NekoPetShop.Core.ApplicationService.Services;
using NekoPetShop.Core.Entity;

namespace NekoPetShop.Tests.ApplicationService.Services
{
	public class ColorServiceTest
	{
		[Fact]
		public void CreateColor_SpecifiedId_ThrowsNotSupportedException()
		{
			Mock<IColorRepository> colorRepository = new Mock<IColorRepository>();
			ColorService colorService = new ColorService(colorRepository.Object);
			Color color = new Color() { Id = 1 };

			Action actual = () => colorService.Create(color);

			Assert.Throws<NotSupportedException>(actual);
		}

		[Fact]
		public void CreateColor_NullName_ThrowsInvalidDataException()
		{
			Mock<IColorRepository> colorRepository = new Mock<IColorRepository>();
			ColorService colorService = new ColorService(colorRepository.Object);
			Color color = new Color();

			Action actual = () => colorService.Create(color);

			Assert.Throws<InvalidDataException>(actual);
		}

		[Fact]
		public void DeleteColor_NonExistingId_ThrowsNullReferenceException()
		{
			Mock<IColorRepository> colorRepository = new Mock<IColorRepository>();
			ColorService colorService = new ColorService(colorRepository.Object);

			Action actual = () => colorService.Delete(1);

			Assert.Throws<NullReferenceException>(actual);
		}

		[Fact]
		public void ReadColorById_NegativeId_ThrowsNullReferenceException()
		{
			Mock<IColorRepository> colorRepository = new Mock<IColorRepository>();
			ColorService colorService = new ColorService(colorRepository.Object);

			Action actual = () => colorService.ReadById(-1);

			Assert.Throws<InvalidDataException>(actual);
		}

		[Fact]
		public void ReadAllColorsFiltered_NegativeCurrentPageOrNegativeItemsPerPage_ThrowsNullReferenceException()
		{
			Mock<IColorRepository> colorRepository = new Mock<IColorRepository>();
			ColorService colorService = new ColorService(colorRepository.Object);
			Filter filter = new Filter() { CurrentPage = -1, ItemsPerPage = -1 };

			Action actual = () => colorService.ReadAll(filter);

			Assert.Throws<InvalidDataException>(actual);
		}
	}
}
