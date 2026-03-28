using IMDb_Movie_Management_System.Models.DB;
using IMDb_Movie_Management_System.Repositories.Interfaces;

namespace IMDb_Movie_Management_System.Repositories.Implementations
{
    public class GenreRepository : IGenreRepository
    {
        private static List<Genre> _genres = new List<Genre>();

        public List<Genre> GetAll()
        {
            return _genres;
        }

        public Genre GetById(int id)
        {
            return _genres.FirstOrDefault(g => g.Id == id);
        }

        public void Add(Genre genre)
        {
            genre.Id = _genres.Count + 1;
            _genres.Add(genre);
        }

        public void Update(Genre genre)
        {
            var existing = GetById(genre.Id);

            if (existing != null)
            {
                existing.Name = genre.Name;
            }
        }

        public void Delete(int id)
        {
            var genre = GetById(id);

            if (genre != null)
            {
                _genres.Remove(genre);
            }
        }
    }
}
