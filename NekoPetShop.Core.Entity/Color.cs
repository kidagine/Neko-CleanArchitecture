using System.Collections.Generic;

namespace NekoPetShop.Core.Entity
{
    public class Color
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PetColor> PetColors { get; set; }
    } 
}
