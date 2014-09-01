using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MariosPizza.Models
{
    public class StoresDbContext : DbContext
    {
        public DbSet<Store> Stores { get; set; }

        static StoresDbContext()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<StoresDbContext>());
        }
    }
}