using IMDb_Movie_Management_System.Models.DB;
using IMDb_Movie_Management_System.Repositories.Interfaces;

namespace IMDb_Movie_Management_System.Repositories.Implementations
{
    public class MovieRepository : IMovieRepository
    {
        private static List<Movie> _movies = new();

        public List<Movie> GetAll() => _movies;

        public Movie GetById(int id) => _movies.FirstOrDefault(x => x.Id == id);

        public void Add(Movie movie)
        {
            movie.Id = _movies.Count + 1;
            _movies.Add(movie);
        }

        public void Update(Movie movie)
        {
            var existing = GetById(movie.Id);
            if (existing != null)
            {
                existing.Name = movie.Name;
                existing.YearOfRelease = movie.YearOfRelease;
                existing.Plot = movie.Plot;
                existing.ProducerId = movie.ProducerId;
                existing.CoverImage = movie.CoverImage;
            }
        }

        public void Delete(int id)
        {
            var movie = GetById(id);
            if (movie != null)
                _movies.Remove(movie);
        }
    }
}
