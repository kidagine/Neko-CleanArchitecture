using System;
using NekoPetShop.Core.Entity;

namespace NekoPetShop.Infrastructure.SQLData
{
    public class DBInitializer
    {
        public static void Seed(NekoPetShopContext ctx)
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
            var own1 = ctx.owners.Add(new Owner() { FirstName = "Son", LastName = "Goku", Address = "King kai's 25", PhoneNumber = "6459124429", Email = "dragonballz@gmail.com" }).Entity;
            var own2 = ctx.owners.Add(new Owner() { FirstName = "Illidan", LastName = "Stormrage", Address = "Thunder bluff 59", PhoneNumber = "5024121920", Email = "arthurSuks@yaho.com" }).Entity;
            ctx.pets.Add(new Pet() { Name = "Charlie", Type = AnimalType.Cat, Birthdate = DateTime.Parse("01/04/2016"), SoldDate = DateTime.Parse("05/25/2016"), Color = "White", PreviousOwner = own1, Price = 50 });
            ctx.pets.Add(new Pet() { Name = "Narlie", Type = AnimalType.Cat, Birthdate = DateTime.Parse("08/05/2013"), SoldDate = DateTime.Parse("10/03/2018"), Color = "Black", PreviousOwner = own2, Price = 78 });
            ctx.pets.Add(new Pet() { Name = "Danny", Type = AnimalType.Cat, Birthdate = DateTime.Parse("01/04/2016"), SoldDate = DateTime.Parse("05/25/2016"), Color = "White", PreviousOwner = own1, Price = 30 });
            ctx.SaveChanges();
        }
    }
}
