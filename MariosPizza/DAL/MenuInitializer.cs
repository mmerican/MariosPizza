using MariosPizza.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MariosPizza.DAL
{
    public class MenuInitializer : DropCreateDatabaseIfModelChanges<MenuDbContext>
    {
        protected override void Seed(MenuDbContext context)
        {
            var menu = new List<Menu>
            {
                new Menu{ItemName="Antipasto Platter", Availability="All", Description="Plate of mixed cheeses and meats", Price=7.95m, NewItem=true, Limited=false, CategoryId=1},
                new Menu{ItemName="Minestrone", Availability="All", Description="Made Daily", Price=4.95m, NewItem=false, Limited=false, CategoryId=2}
            };
            menu.ForEach(s => context.Menus.Add(s));
            context.SaveChanges();

            var categories = new List<MenuCategory> 
            {
                new MenuCategory{CategoryId=1, CategoryName="Appetizers"},
                new MenuCategory{CategoryId=2, CategoryName="Salads and Soups"},
                new MenuCategory{CategoryId=3, CategoryName="Pizzas"}
            };
            categories.ForEach(s => context.MenuCategorys.Add(s));
            context.SaveChanges();
        }
    }
}