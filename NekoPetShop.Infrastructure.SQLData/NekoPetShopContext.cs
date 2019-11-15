    using Microsoft.EntityFrameworkCore;
using NekoPetShop.Core.Entity;

namespace NekoPetShop.Infrastructure.SQLData
{
    public class NekoPetShopContext : DbContext
    {
        public NekoPetShopContext(DbContextOptions<NekoPetShopContext> options) : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pet>().HasOne(p => p.Owner).WithMany(o => o.Pets).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<PetColor>().HasKey(pc => new { pc.PetId, pc.ColorId });
            modelBuilder.Entity<PetColor>().HasOne(pc => pc.Pet).WithMany(p => p.PetColors).HasForeignKey(pc => pc.PetId);
            modelBuilder.Entity<PetColor>().HasOne(pc => pc.Color).WithMany(c => c.PetColors).HasForeignKey(pc => pc.ColorId);
        }

		public DbSet<User> Users { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<PetColor> PetColors { get; set; }
    }
}
