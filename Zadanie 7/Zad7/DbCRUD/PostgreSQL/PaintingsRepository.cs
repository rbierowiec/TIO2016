using System.Collections.Generic;
using System.Data.Entity;
using Zad7.Interfaces;
using Zad7.Models;

namespace Zad7.DbCRUD.PostgreSQL
{
    public class PaintingsRepository : IPaintingsRepository
    {
        private MuseumContext db = new MuseumContext();

        public List<Painting> GetAllPaintings() {
            return parseToList(db.Paintings);
        }

        public Painting GetPainting(int id) {
            return db.Paintings.Find(id);
        }

        public bool AddPainting(Painting painting)
        {
            try
            {
                db.Paintings.Add(painting);
                db.SaveChanges();
            }
            catch {
                return false;
            }

            return true;
        }

        public bool UpdatePainting(Painting painting)
        {
            try
            {
                db.Entry(painting).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch {
                return false;
            }

            return true;
        }

        public bool DeletePainting(int id) {
            try
            {
                db.Paintings.Remove(db.Paintings.Find(id));
                db.SaveChanges();
            }
            catch {
                return false;
            }

            return true;
        }

        private static List<Painting> parseToList(DbSet<Painting> dbset) {
            List<Painting> paintings = new List<Painting>();

            foreach (var painting in dbset) {
                paintings.Add(painting);
            }

            return paintings;
        }

    }
}