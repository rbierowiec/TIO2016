using System.Collections.Generic;
using ObjectsManager.Model;
using System.ServiceModel;
using ObjectsManager.Interface;
using ObjectsManager.DBLite;
using System;

namespace CRUDService2
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class CRUDService2 : ICRUDService2
    {
        private readonly IReviewPersonManager _rpRepo;

        public CRUDService2()
        {
            this._rpRepo = new ReviewPersonManager();
        }

        public List<Review> GetAllReviews()
        {
            return this._rpRepo.GetAllReviews();
        }

        public List<Review> GetReviewsByMovieId(int movieId)
        {
            return this._rpRepo.GetReviewsByMovieId(movieId);
        }

        public List<Review> GetReviewsByAuthor(Person Author)
        {
            return this._rpRepo.GetReviewsByAuthor(Author);
        }

        public List<Person> GetAllAuthors()
        {
            return this._rpRepo.GetAllAuthors();
        }

        public int AddReview(Review rev)
        {
            return this._rpRepo.Add(rev);
        }

        public int AddAuthor(Person author)
        {
            return this._rpRepo.Add(author);
        }

        public Review getReview(int id)
        {
            return this._rpRepo.getReview(id);
        }

        public Person getAuthorById(int id)
        {
            return this._rpRepo.getAuthor(id);
        }

        public Person getAuthorByName(String Name, String Surname)
        {
            return this._rpRepo.getAuthor(Name, Surname);
        }

        public Review UpdateReview(Review rev)
        {
            return this._rpRepo.Update(rev);
        }

        public Person UpdateAuthor(Person author)
        {
            return this._rpRepo.Update(author);
        }

        public bool deleteReview(int id)
        {
            return this._rpRepo.deleteReview(id);
        }

        public bool deleteAuthor(int id) {
            return this._rpRepo.deleteAuthor(id);
        }

    }
}
