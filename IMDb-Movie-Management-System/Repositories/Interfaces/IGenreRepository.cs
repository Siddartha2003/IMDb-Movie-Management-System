using IMDb_Movie_Management_System.Models.DB;

namespace IMDb_Movie_Management_System.Repositories.Interfaces
{
    public interface IGenreRepository
    {
        List<Genre> GetAll();
        Genre GetById(int id);
        void Add(Genre genre);
        void Update(Genre genre);
        void Delete(int id);
    }
}
