using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using HomeBudget.Models;

namespace HomeBudget.DAL
{
    class AppInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<AppContext>
    {
        protected override void Seed(AppContext context)
        {
            var categories = new List<Category>
            {
            new Category{ID=1,Name="Jedzenie"},
            new Category{ID=2,Name="Rozrywka"},
            new Category{ID=3,Name="Fastfood"},
            new Category{ID=4,Name="Slodycze"},
            };

            categories.ForEach(s => context.Categories.Add(s));
            context.SaveChanges();

            var shops = new List<Shop>
            {
            new Shop{ID=1,Name="Lidl"},
            new Shop{ID=2,Name="Biedronka"},
            new Shop{ID=3,Name="x-kom"},
            };
            shops.ForEach(s => context.Shops.Add(s));
            context.SaveChanges();

            var entries = new List<Entry>
            {
            new Entry{ID=1, ShopID=2, Date=DateTime.Parse("2018-01-10"), Price=11.98m, Description="biedronka 13, lodz"},
            };
            entries.ForEach(s => context.Entries.Add(s));
            context.SaveChanges();

            var items = new List<Item>
            {
            new Item{ID=1, EntryID=1, CategoryID=1, Name="Rogalik", Price=2.49m},
            new Item{ID=2, EntryID=1, CategoryID=1, Name="Rogalik", Price=2.49m},
            new Item{ID=3, EntryID=1, CategoryID=4, Name="Czekolada", Price=4.99m}
            };

            items.ForEach(s => context.Items.Add(s));
            context.SaveChanges();


        }
    }
}
