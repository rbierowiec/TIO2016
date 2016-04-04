using System.Collections.Generic;
using ObjectsManager.Model;
using System.ServiceModel;
using ObjectsManager.Interface;
using ObjectsManager.DBLite;

namespace CRUDService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class CRUDService : ICRUDService
    {
        private readonly IMovieManager _movieRepo;

        public CRUDService()
        {
            this._movieRepo = new MovieManager();
        }

        public int AddMovie(Movie movie)
        {
            this._movieRepo.Add(movie);
            return movie.Id;
        }

        public Movie GetMovie(int id)
        {
            return this._movieRepo.Get(id);
        }

        public List<Movie> GetAllMovies()
        {
            return this._movieRepo.GetAll();
        }

        public Movie UpdateMovie(Movie movie)
        {
            this._movieRepo.Update(movie);
            return movie;
        }

        public bool DeleteMovie(int id)
        {
            return this._movieRepo.Delete(id);
        }
    }
}
