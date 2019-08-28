using System;

namespace NekoPetShop.Core.Entity
{
    public enum AnimalType { Cat, Dog, Goat, Dragon };

    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AnimalType Type { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime SoldDate { get; set; }
        public string Color { get; set; }
        public string PreviousOwner { get; set; }
        public double Price { get; set; }
    }
}
