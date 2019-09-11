using Microsoft.EntityFrameworkCore;
using NekoPetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NekoPetShop.Infastructure.SQLData
{
    class Context: DbContext
    {
        public Context(DbContextOptions<Context> opt): base(opt)
        {

        }

        public DbSet<Owner> owners { get; set; }
        public DbSet<Pet> pets { get; set; }
    }
}
