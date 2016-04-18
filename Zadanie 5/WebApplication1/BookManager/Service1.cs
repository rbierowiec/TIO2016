using Library1;
using LiteDB;
using System.Collections.Generic;
using System.Linq;

namespace BookManager
{
    public class Service1 : IService1
    {
        private readonly string _connection = "books.db";

        public List<Book> GetAllBooks()
        {
            using (var db = new LiteDatabase(this._connection))
            {
                var repository = db.GetCollection<Book>("books");
                var results = repository.FindAll();

                return results.ToList();
            }
        }
        
        public int Add(Book book)
        {
            using (var db = new LiteDatabase(this._connection))
            {
                var dbObject = book;

                var repository = db.GetCollection<Book>("books");
                if (repository.FindById(book.Id) != null)
                    repository.Update(dbObject);
                else
                    repository.Insert(dbObject);

                return dbObject.Id;
            }
        }

        public Book getBook(int id)
        {
            using (var db = new LiteDatabase(this._connection))
            {
                var repository = db.GetCollection<Book>("books");
                var result = repository.FindById(id);
                return result;
            }
        }

        public Book Update(Book book)
        {
            using (var db = new LiteDatabase(this._connection))
            {
                var dbObject = book;

                var repository = db.GetCollection<Book>("books");
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
                var repository = db.GetCollection<Book>("books");
                return repository.Delete(id);
            }
        }
    }
}
