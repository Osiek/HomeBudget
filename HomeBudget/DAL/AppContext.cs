using HomeBudget.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace HomeBudget.DAL
{
    class AppContext : DbContext
    {
        public AppContext() : base("AppContext")
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Entry> Entries { get; set; }
        public DbSet<Item> Items { get; set; }
        //public DbSet<ItemCategory> ItemCategories { get; set; }
        public DbSet<Shop> Shops { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
