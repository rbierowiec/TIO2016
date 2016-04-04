using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectsManager.Interface;
using ObjectsManager.Model;
using LiteDB;

namespace ObjectsManager.DBLite
{
    public class ReviewPersonManager : IReviewPersonManager
    {
        private readonly string _connection = DatabaseConnection.ReviewPersonConnection;

        public List<Review> GetAllReviews()
        {
            using (var db = new LiteDatabase(this._connection))
            {
                var repository = db.GetCollection<Review>("reviews");
                var results = repository.FindAll();

                return results.ToList();
            }
        }

        public List<Review> GetReviewsByMovieId(int movieId)
        {
            using (var db = new LiteDatabase(this._connection))
            {
                var repository = db.GetCollection<Review>("reviews");
                var results = repository.Find(x => x.MovieId == movieId);

                return results.ToList();
            }
        }

        public List<Review> GetReviewsByAuthor(Person author)
        {
            using (var db = new LiteDatabase(this._connection))
            {
                var repository = db.GetCollection<Review>("reviews");
                var results = repository.Find(x => x.Author.Id == author.Id);

                return results.ToList();
            }
        }

        public List<Person> GetAllAuthors()
        {
            using (var db = new LiteDatabase(this._connection))
            {
                var repository = db.GetCollection<Person>("people");
                var results = repository.FindAll();

                return results.ToList();
            }
        }

        public int Add(Review rev)
        {
            using (var db = new LiteDatabase(this._connection))
            {
                var repository = db.GetCollection<Review>("reviews");
                repository.Insert(rev);

                return rev.Id;
            }
        }

        public int Add(Person author)
        {
            using (var db = new LiteDatabase(this._connection))
            {
                var repository = db.GetCollection<Person>("people");
                repository.Insert(author);

                return author.Id;
            }
        }

        public Review getReview(int Id)
        {
            using (var db = new LiteDatabase(this._connection))
            {
                var repository = db.GetCollection<Review>("reviews");
                var result = repository.FindById(Id);

                return result;
            }
        }

        public Person getAuthor(int Id)
        {
            using (var db = new LiteDatabase(this._connection))
            {
                var repository = db.GetCollection<Person>("people");
                var result = repository.FindById(Id);

                return result;
            }
        }

        public Person getAuthor(String Name, String Surname)
        {
            using (var db = new LiteDatabase(this._connection))
            {
                var repository = db.GetCollection<Person>("people");
                var result = repository.FindOne(x => x.Name == Name && x.Surname == Surname);

                return result;
            }
        }

        public Review Update(Review rev)
        {
            using (var db = new LiteDatabase(this._connection))
            {
                var repository = db.GetCollection<Review>("reviews");
                if (repository.Update(rev))
                    return rev;
                else
                    return null;
            }
        }

        public Person Update(Person author)
        {
            using (var db = new LiteDatabase(this._connection))
            {
                var repository = db.GetCollection<Person>("people");
                if (repository.Update(author))
                    return author;
                else
                    return null;
            }
        }

        public bool deleteReview(int id)
        {
            using (var db = new LiteDatabase(this._connection))
            {
                var repository = db.GetCollection<Review>("reviews");
                return repository.Delete(id);
            }
        }

        public bool deleteAuthor(int id)
        {
            using (var db = new LiteDatabase(this._connection))
            {
                var repository = db.GetCollection<Person>("people");
                return repository.Delete(id);
            }
        }
    }
}
