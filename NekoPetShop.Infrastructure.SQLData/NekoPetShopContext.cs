using Microsoft.EntityFrameworkCore;
using NekoPetShop.Core.Entity;

namespace NekoPetShop.Infrastructure.SQLData
{
    public class NekoPetShopContext : DbContext
    {
        public NekoPetShopContext(DbContextOptions<NekoPetShopContext> opt) : base(opt)
        {

        }

        public DbSet<Owner> owners { get; set; }
        public DbSet<Pet> pets { get; set; }
    }
}
