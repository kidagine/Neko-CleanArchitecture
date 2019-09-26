using System.Collections.Generic;
using NekoPetShop.Core.Entity;

namespace NekoPetShop.Core.DomainService
{
    public interface IColorRepository
    {
        Color Create(Color color);
        Color Update(Color color);
        Color Delete(int id);
        Color ReadById(int id);
        IEnumerable<Color> ReadAll(Filter filter = null);
    }
}
