using System.Data.Entity;
using Zad6b.Models;

namespace Zad6b.Context
{
    public class StoreContext : DbContext
    {
        public StoreContext() : base("StoreContext") { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
        }
    }
}