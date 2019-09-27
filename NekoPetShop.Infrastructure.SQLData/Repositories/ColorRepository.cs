using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NekoPetShop.Core.Entity;
using NekoPetShop.Core.DomainService;

namespace NekoPetShop.Infrastructure.SQLData.Repositories
{
    public class ColorRepository : IColorRepository
    {
        private readonly NekoPetShopContext _context;


        public ColorRepository(NekoPetShopContext context)
        {
            _context = context;
        }

        public Color Create(Color color)
        {
            _context.Attach(color).State = EntityState.Added;
            _context.SaveChanges();
            return color;
        }

        public Color Update(Color color)
        {
            _context.Attach(color).State = EntityState.Modified;
            _context.SaveChanges();
            return color;
        }
            
        public Color Delete(int id)
        {
            Color color = ReadById(id);
            _context.Attach(color).State = EntityState.Deleted;
            _context.SaveChanges();
            return color;
        }

        public Color ReadById(int id)
        {
            return _context.Colors.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Color> ReadAll(Filter filter = null)
        {
            IEnumerable<Color> filteredColors;
            if (filter.CurrentPage != 0 && filter.ItemsPerPage != 0)
            {
                if (filter.OrderByType == OrderByType.Ascending)
                {
                    filteredColors = _context.Colors.Include(c => c.PetColors).ThenInclude(pc => pc.Color).Skip((filter.CurrentPage - 1) * filter.ItemsPerPage).Take(filter.ItemsPerPage).OrderBy(c => c.Id);
                }
                else
                {
                    filteredColors = _context.Colors.Include(c => c.PetColors).ThenInclude(pc => pc.Color).Skip((filter.CurrentPage - 1) * filter.ItemsPerPage).Take(filter.ItemsPerPage).OrderBy(c => c.Id).Reverse();
                }
            }
            else
            {
                filteredColors = _context.Colors;
            }
            return filteredColors;
        }
    }
}
