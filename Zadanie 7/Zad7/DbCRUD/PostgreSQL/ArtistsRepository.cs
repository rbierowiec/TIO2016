using System.Collections.Generic;
using System.Data.Entity;
using Zad7.Interfaces;
using Zad7.Models;

namespace Zad7.DbCRUD.PostgreSQL
{
    public class ArtistsRepository : IArtistsRepository
    {
        private MuseumContext db = new MuseumContext();

        public List<Artist> GetAllArtists()
        {
            return parseToList(db.Artists);
        }

        public Artist GetArtist(int id)
        {
            return db.Artists.Find(id);
        }

        public void AddArtits(Artist artist)
        {
            db.Artists.Add(artist);
            db.SaveChanges();
        }

        public void UpdateArtist(Artist artist)
        {
            db.Entry(artist).State = EntityState.Modified;
            db.SaveChanges();
        }

        public bool DeleteArtist(int id)
        {
            try
            {
                db.Artists.Remove(db.Artists.Find(id));
                db.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }

        private static List<Artist> parseToList(DbSet<Artist> dbset)
        {
            List<Artist> artists = new List<Artist>();

            foreach (var artist in dbset)
            {
                artists.Add(artist);
            }

            return artists;
        }
    }
}