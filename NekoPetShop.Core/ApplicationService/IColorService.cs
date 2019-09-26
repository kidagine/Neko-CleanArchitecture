using System.Collections.Generic;
using NekoPetShop.Core.Entity;

namespace NekoPetShop.Core.ApplicationService
{
    public interface IColorService
    {
        Color New(string name);
        Color Create(Color color);
        Color Update(Color color);
        Color Delete(int id);
        Color ReadById(int id);
        List<Color> ReadAll(Filter filter = null);
    }
}
