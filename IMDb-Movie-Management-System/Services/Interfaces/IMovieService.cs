using IMDb_Movie_Management_System.Models.Request;
using IMDb_Movie_Management_System.Models.Response;

namespace IMDb_Movie_Management_System.Services.Interfaces
{
    public interface IMovieService
    {
        List<MovieResponse> Get(int? year);
        MovieResponse Get(int id);
        void Create(MovieRequest request);
        void Update(int id, MovieRequest request);
        void Delete(int id);
    }
}
