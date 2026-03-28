using IMDb_Movie_Management_System.Models.Request;
using IMDb_Movie_Management_System.Models.Response;

namespace IMDb_Movie_Management_System.Services.Interfaces
{
    public interface IReviewService
    {
        List<ReviewResponse> Get();
        ReviewResponse Get(int id);
        List<ReviewResponse> GetByMovie(int movieId);
        void Create(ReviewRequest request);
        void Update(int id, ReviewRequest request);
        void Delete(int id);
    }
}
