using LiteDB;
using System.Collections.Generic;
using System.Linq;
using Zad7.Interfaces;
using Zad7.Models;

namespace Zad7.DbCRUD.LiteDB
{
    public class ArtistsRepository : IArtistsRepository
    {
        private readonly string _connection = "artists.db";

        public List<Artist> GetAllArtists()
        {
            using (var db = new LiteDatabase(this._connection))
            {
                var repository = db.GetCollection<Artist>("artists");
                var results = repository.FindAll();

                return results.ToList();
            }
        }

        public Artist GetArtist(int id)
        {
            using (var db = new LiteDatabase(this._connection))
            {
                var repository = db.GetCollection<Artist>("artists");
                var result = repository.FindById(id);
                return result;
            }
        }

        public void AddArtits(Artist artist)
        {
            using (var db = new LiteDatabase(this._connection))
            {
                var dbObject = artist;

                var repository = db.GetCollection<Artist>("artists");
                if (repository.FindById(artist.Id) != null)
                    repository.Update(dbObject);
                else
                    repository.Insert(dbObject);
            }
        }

        public void UpdateArtist(Artist artist)
        {
            using (var db = new LiteDatabase(this._connection))
            {
                var dbObject = artist;

                var repository = db.GetCollection<Artist>("artists");
                repository.Update(dbObject);
            }
        }

        public bool DeleteArtist(int id)
        {
            using (var db = new LiteDatabase(this._connection))
            {
                var repository = db.GetCollection<Artist>("artists");
                return repository.Delete(id);
            }
        }
    }
}