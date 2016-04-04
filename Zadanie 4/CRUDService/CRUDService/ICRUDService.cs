using System.Collections.Generic;
using System.ServiceModel;
using ObjectsManager.Model;

namespace CRUDService
{
    [ServiceContract]
    interface ICRUDService
    {
        [OperationContract]
        int AddMovie(Movie movie);

        [OperationContract]
        Movie GetMovie(int id);

        [OperationContract]
        List<Movie> GetAllMovies();

        [OperationContract]
        Movie UpdateMovie(Movie movie);

        [OperationContract]
        bool DeleteMovie(int id);
    }
}
