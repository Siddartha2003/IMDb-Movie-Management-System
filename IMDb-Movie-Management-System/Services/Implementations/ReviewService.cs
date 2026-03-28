using IMDb_Movie_Management_System.Models.DB;
using IMDb_Movie_Management_System.Models.Request;
using IMDb_Movie_Management_System.Models.Response;
using IMDb_Movie_Management_System.Repositories.Interfaces;
using IMDb_Movie_Management_System.Services.Interfaces;

namespace IMDb_Movie_Management_System.Services.Implementations
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _repo;

        public ReviewService(IReviewRepository repo)
        {
            _repo = repo;
        }

        public List<ReviewResponse> Get()
        {
            return _repo.GetAll().Select(r => new ReviewResponse
            {
                Id = r.Id,
                Message = r.Message,
                MovieId = r.MovieId
            }).ToList();
        }

        public ReviewResponse Get(int id)
        {
            var review = _repo.GetById(id);

            if (review == null)
                throw new Exception("NotFound");

            return new ReviewResponse
            {
                Id = review.Id,
                Message = review.Message,
                MovieId = review.MovieId
            };
        }

        public void Create(ReviewRequest request)
        {
            if (string.IsNullOrEmpty(request.Message))
                throw new Exception("Message required");

            _repo.Add(new Review
            {
                Message = request.Message,
                MovieId = request.MovieId
            });
        }

        public void Update(int id, ReviewRequest request)
        {
            var review = _repo.GetById(id);

            if (review == null)
                throw new Exception("NotFound");

            review.Message = request.Message;
            review.MovieId = request.MovieId;

            _repo.Update(review);
        }

        public void Delete(int id)
        {
            if (_repo.GetById(id) == null)
                throw new Exception("NotFound");

            _repo.Delete(id);
        }

        public List<ReviewResponse> GetByMovie(int movieId)
        {
            throw new NotImplementedException();
        }
    }
}
