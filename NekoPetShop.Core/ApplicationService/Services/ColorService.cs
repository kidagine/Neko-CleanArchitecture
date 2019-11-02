using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using NekoPetShop.Core.Entity;
using NekoPetShop.Core.DomainService;

namespace NekoPetShop.Core.ApplicationService.Services
{
    public class ColorService : IColorService
    {
        private readonly IColorRepository _colorRepository;


        public ColorService(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }

        public Color New(string name)
        {
            Color color = new Color() { Name = name };
            return color;
        }

        public Color Create(Color color)
        {
            if (color.Id != default)
            {
                throw new NotSupportedException($"The color id should not be specified");
            }
            else if (string.IsNullOrEmpty(color.Name))
            {
                throw new InvalidDataException("You need to specify the color's name.");
            }
            return _colorRepository.Create(color);
        }

        public Color Update(Color color)
        {
            if (string.IsNullOrEmpty(color.Name))
            {
                throw new InvalidDataException("You need to specify the color's name.");
            }
            return _colorRepository.Update(color);
        }

        public Color Delete(int id)
        {
            Color color = _colorRepository.ReadById(id);
            if (color == null)
            {
                throw new NullReferenceException($"The color with Id: {id} does not exist");
            }
            return _colorRepository.Delete(id);
        }

        public Color ReadById(int id)
        {
            return _colorRepository.ReadById(id);
        }

        public List<Color> ReadAll(Filter filter = null)
        {
            if (filter.CurrentPage < 0 || filter.ItemsPerPage < 0)
            {
                throw new InvalidDataException("Current Page and Items Page have to be zero or more");
            }
            return _colorRepository.ReadAll(filter).ToList();
        }
    }
}
