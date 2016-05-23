using System.Data.Entity;

namespace Library
{
    public class GamesContext : DbContext
    {
        public GamesContext() : base("GamesContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer<GamesContext>(null);
        }

        public DbSet<Store> Stores { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<CardShirt> CardShirts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
        }
    }
}