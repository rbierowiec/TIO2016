using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Zad7.Models;

namespace Zad7.Initializers
{
    public class MuseumInitializer : DropCreateDatabaseIfModelChanges<MuseumContext>
    {
        protected override void Seed(MuseumContext context)
        {
            var paintings = new List<Painting>()
            {
                new Painting() { Title = "Title1", Year = 2015},
                new Painting() { Title = "Title2", Year = 2014}
            };

            paintings.ForEach(i => context.Paintings.Add(i));
            context.SaveChanges();

            var artists = new List<Artist>()
            {
                new Artist() { ArtistName = "Name1" , ArtistSurname = "Surname1" },
                new Artist() { ArtistName = "Name2" , ArtistSurname = "Surname2" }
            };

            artists.ForEach(g => context.Artists.Add(g));
            context.SaveChanges();
        }
    }
}