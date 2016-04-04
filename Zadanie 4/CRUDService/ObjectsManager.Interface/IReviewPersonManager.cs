using System;
using System.Collections.Generic;
using ObjectsManager.Model;

namespace ObjectsManager.Interface
{
    public interface IReviewPersonManager
    {
        List<Review> GetAllReviews();
        List<Review> GetReviewsByMovieId(int movieId);
        List<Review> GetReviewsByAuthor(Person Author);
        List<Person> GetAllAuthors();
        int Add(Review rev);
        int Add(Person author);
        Review getReview(int id);
        Person getAuthor(int id);
        Person getAuthor(String Name, String Surname);
        Review Update(Review second);
        Person Update(Person second);
        bool deleteReview(int id);
        bool deleteAuthor(int id);
    }
}
