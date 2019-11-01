using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NekoPetShop.Core.Entity;
using NekoPetShop.Core.DomainService;
using NekoPetShop.Core.Entity.Filtering;

namespace NekoPetShop.Infrastructure.SQLData.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly NekoPetShopContext _context;


        public PetRepository(NekoPetShopContext context)
        {
            _context = context;
        }

        public Pet Create(Pet pet)
        {
            _context.Attach(pet).State = EntityState.Added;
            _context.SaveChanges();
            return pet;
        }

        public Pet Update(Pet pet)
        {
			List<PetColor> allPetColors = _context.PetColors.ToList();
			allPetColors.ForEach(pc =>
			{
				if (!pet.PetColors.Exists(
					petColor => petColor.ColorId == pc.ColorId))
				{
					_context.PetColors.Remove(pc);
				}
			});

			pet.PetColors.RemoveAll(
				pc => allPetColors.Exists(
					petColor => petColor.ColorId == pc.ColorId &&
					petColor.PetId == pet.Id));

			pet.PetColors.ForEach(pc =>
			{
				_context.PetColors.Add(new PetColor() { ColorId = pc.ColorId, PetId = pet.Id });
			});
			pet.PetColors = null;

			_context.Attach(pet).State = EntityState.Modified;
			_context.Entry(pet).Reference(p => p.Owner).IsModified = true;

			_context.SaveChanges();
			return pet;
		}

        public Pet Delete(int id)
        {
            Pet pet = ReadById(id);
            _context.Attach(pet).State = EntityState.Deleted;
            _context.SaveChanges();
            return pet;
        }

        public Pet ReadById(int id)
        {
            return _context.Pets.AsNoTracking().Include(p => p.Owner).Include(p => p.PetColors).ThenInclude(pc => pc.Pet).FirstOrDefault(p => p.Id == id);     
        }

		public FilteredList<Pet> ReadAll(Filter filter = null)
		{
			FilteredList<Pet> filteredList = new FilteredList<Pet>();
			if (filter.CurrentPage != 0 && filter.ItemsPerPage != 0)
			{
				if (filter.OrderByType == OrderByType.Ascending)
				{
					filteredList.List = SortByType(filter).Skip((filter.CurrentPage - 1) * filter.ItemsPerPage).Take(filter.ItemsPerPage);
				}
				else
				{
					filteredList.List = SortByType(filter).Reverse().Skip((filter.CurrentPage - 1) * filter.ItemsPerPage).Take(filter.ItemsPerPage);
				}
			}
			else
			{
				filteredList.List = _context.Pets.Include(p => p.Owner);
			}

			if (filter.AnimalType == AnimalType.All)
			{
				if (_context.Pets.Count() % filter.ItemsPerPage != 0)
				{
					filteredList.TotalPages = (_context.Pets.Count() / filter.ItemsPerPage) + 1;
				}
				else
				{
					filteredList.TotalPages = _context.Pets.Count() / filter.ItemsPerPage;
				}
			}
			else
			{
				int totalFilteredPets = _context.Pets.Where(p => p.Type == filter.AnimalType).Count();
				if (totalFilteredPets % filter.ItemsPerPage != 0)
				{
					filteredList.TotalPages = (totalFilteredPets / filter.ItemsPerPage) + 1;
				}
				else
				{
					filteredList.TotalPages = totalFilteredPets / filter.ItemsPerPage;
				}
			}
			return filteredList;
        }

        private IEnumerable<Pet> SortByType(Filter filter)
        {
			if (filter.AnimalType == AnimalType.All)
			{
				switch (filter.SortType)
				{
					case SortType.Id:
						return _context.Pets.Include(p => p.PetColors).ThenInclude(pc => pc.Pet).Include(p => p.Owner).OrderBy(p => p.Id);
					case SortType.Name:
						return _context.Pets.Include(p => p.PetColors).ThenInclude(pc => pc.Pet).Include(p => p.Owner).OrderBy(p => p.Name);
					case SortType.Birthday:
						return _context.Pets.Include(p => p.PetColors).ThenInclude(pc => pc.Pet).Include(p => p.Owner).OrderBy(p => p.Birthdate);
					case SortType.Price:
						return _context.Pets.Include(p => p.PetColors).ThenInclude(pc => pc.Pet).Include(p => p.Owner).OrderBy(p => p.Price);
					case SortType.ProductDate:
						return _context.Pets.Include(p => p.PetColors).ThenInclude(pc => pc.Pet).Include(p => p.Owner).OrderBy(p => p.ProductDate);
					default:
						return _context.Pets;
				}
			}
			else
			{
				switch (filter.SortType)
				{
					case SortType.Id:
						return _context.Pets.Where(p => p.Type == filter.AnimalType).Include(p => p.PetColors).ThenInclude(pc => pc.Pet).Include(p => p.Owner).OrderBy(p => p.Id);
					case SortType.Name:
						return _context.Pets.Where(p => p.Type == filter.AnimalType).Include(p => p.PetColors).ThenInclude(pc => pc.Pet).Include(p => p.Owner).OrderBy(p => p.Name);
					case SortType.Birthday:
						return _context.Pets.Where(p => p.Type == filter.AnimalType).Include(p => p.PetColors).ThenInclude(pc => pc.Pet).Include(p => p.Owner).OrderBy(p => p.Birthdate);
					case SortType.Price:
						return _context.Pets.Where(p => p.Type == filter.AnimalType).Include(p => p.PetColors).ThenInclude(pc => pc.Pet).Include(p => p.Owner).OrderBy(p => p.Price);
					case SortType.ProductDate:
						return _context.Pets.Where(p => p.Type == filter.AnimalType).Include(p => p.PetColors).ThenInclude(pc => pc.Pet).Include(p => p.Owner).OrderBy(p => p.ProductDate);
					default:
						return _context.Pets.Where(p => p.Type == filter.AnimalType);
				}
			}
        }
    }
}
