using Microsoft.EntityFrameworkCore;
using NekoPetShop.Core.Entity;

namespace NekoPetShop.Infrastructure.SQLData
{
    public class NekoPetShopContext : DbContext
    {
        public NekoPetShopContext(DbContextOptions<NekoPetShopContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pet>().HasOne(p => p.Owner).WithMany(o => o.Pets).OnDelete(DeleteBehavior.SetNull);
        }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pet> Pets { get; set; }
    }
}
