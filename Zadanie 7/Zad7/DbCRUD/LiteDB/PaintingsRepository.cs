using LiteDB;
using System.Collections.Generic;
using System.Linq;
using Zad7.Interfaces;
using Zad7.Models;

namespace Zad7.DbCRUD.LiteDB
{
    public class PaintingsRepository : IPaintingsRepository
    {
        private readonly string _connection = "paintings.db";

        public List<Painting> GetAllPaintings()
        {
            using (var db = new LiteDatabase(this._connection))
            {
                var repository = db.GetCollection<Painting>("paintings");
                var results = repository.FindAll();

                return results.ToList();
            }
        }

        public Painting GetPainting(int id)
        {
            using (var db = new LiteDatabase(this._connection))
            {
                var repository = db.GetCollection<Painting>("paintings");
                var result = repository.FindById(id);
                return result;
            }
        }

        public bool AddPainting(Painting painting)
        {
            using (var db = new LiteDatabase(this._connection))
            {
                var dbObject = painting;

                var repository = db.GetCollection<Painting>("paintings");
                if (repository.FindById(painting.Id) != null)
                    repository.Update(dbObject);
                else
                    repository.Insert(dbObject);

                return true;
            }
        }

        public bool UpdatePainting(Painting painting)
        {
            using (var db = new LiteDatabase(this._connection))
            {
                var dbObject = painting;

                var repository = db.GetCollection<Painting>("paintings");
                repository.Update(dbObject);

                return true;
            }
        }

        public bool DeletePainting(int id)
        {
            using (var db = new LiteDatabase(this._connection))
            {
                var repository = db.GetCollection<Painting>("paintings");
                return repository.Delete(id);
            }
        }

    }
}