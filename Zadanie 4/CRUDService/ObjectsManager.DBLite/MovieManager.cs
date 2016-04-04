using ObjectsManager.Model;
using ObjectsManager.Interface;
using System.Collections.Generic;
using System.Data;
using LiteDB;
using System.Linq;

namespace ObjectsManager.DBLite
{
    public class MovieManager : IMovieManager
    {
        private readonly string _connection = DatabaseConnection.MoviesConnection;

        public List<Movie> GetAll()
        {
            using (var db = new LiteDatabase(this._connection))
            {
                var repository = db.GetCollection<Movie>("movies");
                var results = repository.FindAll();

                return results.ToList();
            }
        }

        public int Add(Movie movie)
        {
            using (var db = new LiteDatabase(this._connection))
            {
                var dbObject = movie;

                var repository = db.GetCollection<Movie>("movies");
                if (repository.FindById(movie.Id) != null)
                    repository.Update(dbObject);
                else
                    repository.Insert(dbObject);

                return dbObject.Id;
            }
        }

        public Movie Update(Movie movie)
        {
            using (var db = new LiteDatabase(this._connection))
            {
                var dbObject = movie;

                var repository = db.GetCollection<Movie>("movies");
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
                var repository = db.GetCollection<Movie>("movies");
                return repository.Delete(id);
            }
        }

        public Movie Get(int id)
        {
            using (var db = new LiteDatabase(this._connection))
            {
                var repository = db.GetCollection<Movie>("movies");
                var result = repository.FindById(id);
                return result;
            }
        }

        List<Movie> GetMovies(int[] ids)
        {
            using (var db = new LiteDatabase(this._connection))
            {
                var repository = db.GetCollection<Movie>("movies");
                var results = repository.FindAll().Where(x => ids.Contains(x.Id));

                return results.ToList();
            }
        }
    }
}
