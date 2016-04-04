using ObjectsManager.Model;
using System.Collections.Generic;

namespace ObjectsManager.Interface
{
    public interface IMovieManager
    {
        List<Movie> GetAll();
        int Add(Movie movie);
        Movie Get(int id);
        Movie Update(Movie movie);
        bool Delete(int id);
    }
}
