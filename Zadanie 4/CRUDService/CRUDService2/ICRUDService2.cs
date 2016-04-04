using System.Collections.Generic;
using System.ServiceModel;
using ObjectsManager.Model;
using System;

namespace CRUDService2
{
    [ServiceContract]
    interface ICRUDService2
    {
        [OperationContract]
        List<Review> GetAllReviews();

        [OperationContract]
        List<Review> GetReviewsByMovieId(int movieId);

        [OperationContract]
        List<Review> GetReviewsByAuthor(Person Author);

        [OperationContract]
        List<Person> GetAllAuthors();

        [OperationContract]
        int AddReview(Review rev);

        [OperationContract]
        int AddAuthor(Person author);

        [OperationContract]
        Review getReview(int id);

        [OperationContract]
        Person getAuthorById(int id);

        [OperationContract]
        Person getAuthorByName(String Name, String Surname);

        [OperationContract]
        Review UpdateReview(Review second);

        [OperationContract]
        Person UpdateAuthor(Person second);

        [OperationContract]
        bool deleteReview(int id);

        [OperationContract]
        bool deleteAuthor(int id);
    }
}
