using AuthorManager;
using Library1;
using LiteDB;
using System.Collections.Generic;
using System.Linq;

namespace AuthorManager
{
    public class Service1 : IService1
    {
        private readonly string _connection = "authors.db";

        public List<Author> GetAllAuthors()
        {
            using (var db = new LiteDatabase(this._connection))
            {
                var repository = db.GetCollection<Author>("authors");
                var results = repository.FindAll();

                return results.ToList();
            }
        }

        public int Add(Author author)
        {
            using (var db = new LiteDatabase(this._connection))
            {
                var dbObject = author;

                var repository = db.GetCollection<Author>("authors");
                if (repository.FindById(author.Id) != null)
                    repository.Update(dbObject);
                else
                    repository.Insert(dbObject);

                return dbObject.Id;
            }
        }

        public Author getAuthor(int id)
        {
            using (var db = new LiteDatabase(this._connection))
            {
                var repository = db.GetCollection<Author>("authors");
                var result = repository.FindById(id);
                return result;
            }
        }

        public Author Update(Author author)
        {
            using (var db = new LiteDatabase(this._connection))
            {
                var dbObject = author;

                var repository = db.GetCollection<Author>("authors");
                if (repository.Update(dbObject))
                    return dbObject;
                else
                    return null;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new LiteDatabase(this._connection))
            {
                var repository = db.GetCollection<Author>("authors");
                return repository.Delete(id);
            }
        }
    }
}
