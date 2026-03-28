using IMDb_Movie_Management_System.Models.Request;
using IMDb_Movie_Management_System.Models.Response;

namespace IMDb_Movie_Management_System.Services.Interfaces
{
    public interface IGenreService
    {
        List<GenreResponse> Get();
        GenreResponse Get(int id);
        void Create(GenreRequest request);
        void Update(int id, GenreRequest request);
        void Delete(int id);
    }
}
