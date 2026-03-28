using IMDb_Movie_Management_System.Models.DB;
using IMDb_Movie_Management_System.Repositories.Interfaces;

namespace IMDb_Movie_Management_System.Repositories.Implementations
{
    public class ReviewRepository : IReviewRepository
    {
        private static List<Review> _reviews = new List<Review>();

        public List<Review> GetAll()
        {
            return _reviews;
        }

        public Review GetById(int id)
        {
            return _reviews.FirstOrDefault(r => r.Id == id);
        }

        public void Add(Review review)
        {
            review.Id = _reviews.Count + 1;
            _reviews.Add(review);
        }

        public void Update(Review review)
        {
            var existing = GetById(review.Id);

            if (existing != null)
            {
                existing.Message = review.Message;
                existing.MovieId = review.MovieId;
            }
        }

        public void Delete(int id)
        {
            var review = GetById(id);

            if (review != null)
            {
                _reviews.Remove(review);
            }
        }
    }
}
