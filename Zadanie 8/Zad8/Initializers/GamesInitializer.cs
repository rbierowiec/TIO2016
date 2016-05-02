using System.Collections.Generic;
using Zad8.Contexts;
using Zad8.Models;

namespace Zad8.Initializers
{
    public class GamesInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<GamesContext>
    {
        protected override void Seed(GamesContext context)
        {
            var games = new List<Game>()
            {
                new Game() { AgeRate = 18, CreatorCompany = "Creator1", Title = "Title1", Year = 2015},
                new Game() { AgeRate = 18, CreatorCompany = "Creator2", Title = "Title2", Year = 2015},
                new Game() { AgeRate = 18, CreatorCompany = "Creator3", Title = "Title3", Year = 2015},
                new Game() { AgeRate = 18, CreatorCompany = "Creator4", Title = "Title4", Year = 2015},
                new Game() { AgeRate = 18, CreatorCompany = "Creator5", Title = "Title5", Year = 2015}
            };

            games.ForEach(i => context.Games.Add(i));
            context.SaveChanges();

            var stores = new List<Store>()
            {
                new Store() { Address = "Address1", Name = "Name1"},
                new Store() { Address = "Address2", Name = "Name2"},
                new Store() { Address = "Address3", Name = "Name3"},
                new Store() { Address = "Address4", Name = "Name4"},
                new Store() { Address = "Address5", Name = "Name5"}
            };

            stores.ForEach(g => context.Stores.Add(g));
            context.SaveChanges();
        }
    }
}