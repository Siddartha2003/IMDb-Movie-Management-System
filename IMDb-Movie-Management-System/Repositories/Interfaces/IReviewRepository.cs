using IMDb_Movie_Management_System.Models.DB;

namespace IMDb_Movie_Management_System.Repositories.Interfaces
{
    public interface IReviewRepository
    {
        List<Review> GetAll();
        Review GetById(int id);
        void Add(Review review);
        void Update(Review review);
        void Delete(int id);
    }
}
