using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace MariosPizza.Models
{
    public class MenuDbContext : DbContext
    {
        public MenuDbContext() : base("MenuDbContext")
        {

        }

        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuCategory> MenuCategorys { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}