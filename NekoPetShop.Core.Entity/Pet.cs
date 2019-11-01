using System;
using System.Collections.Generic;

namespace NekoPetShop.Core.Entity
{
    public enum AnimalType { All, Cat, Dog, Goat, Dragon, Pug, Gundam };

    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AnimalType Type { get; set; }
		public DateTime ProductDate { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime SoldDate { get; set; }
        public List<PetColor> PetColors { get; set; }
        public Owner Owner { get; set; }
        public double Price { get; set; }
    }
}
