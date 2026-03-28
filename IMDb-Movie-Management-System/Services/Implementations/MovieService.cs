using IMDb_Movie_Management_System.Models.DB;
using IMDb_Movie_Management_System.Models.Request;
using IMDb_Movie_Management_System.Models.Response;
using IMDb_Movie_Management_System.Repositories.Interfaces;
using IMDb_Movie_Management_System.Services.Interfaces;

namespace IMDb_Movie_Management_System.Services.Implementations
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repo;

        public MovieService(IMovieRepository repo)
        {
            _repo = repo;
        }

        public List<MovieResponse> Get(int? year)
        {
            var movies = _repo.GetAll();

            if (year.HasValue)
            {
                movies = movies.Where(x => x.YearOfRelease == year).ToList();
            }

            return movies.Select(x => new MovieResponse
            {
                Id = x.Id,
                Name = x.Name,
                YearOfRelease = x.YearOfRelease,
                Plot = x.Plot,
                Actors = new List<string>(),
                Genres = new List<string>(),
                Producer = ""
            }).ToList();
        }

        public MovieResponse Get(int id)
        {
            var movie = _repo.GetById(id);

            if (movie == null)
                throw new Exception("NotFound");

            return new MovieResponse
            {
                Id = movie.Id,
                Name = movie.Name,
                YearOfRelease = movie.YearOfRelease,
                Plot = movie.Plot,
                Actors = new List<string>(),
                Genres = new List<string>(),
                Producer = ""
            };
        }

        public void Create(MovieRequest request)
        {
            if (string.IsNullOrEmpty(request.Name))
                throw new Exception("Name required");

            var movie = new Movie
            {
                Name = request.Name,
                YearOfRelease = request.YearOfRelease,
                Plot = request.Plot,
                ProducerId = request.ProducerId,
                CoverImage = request.CoverImage
            };

            _repo.Add(movie);
        }

        public void Update(int id, MovieRequest request)
        {
            var movie = _repo.GetById(id);

            if (movie == null)
                throw new Exception("NotFound");

            movie.Name = request.Name;
            movie.YearOfRelease = request.YearOfRelease;
            movie.Plot = request.Plot;
            movie.ProducerId = request.ProducerId;
            movie.CoverImage = request.CoverImage;

            _repo.Update(movie);
        }

        public void Delete(int id)
        {
            var movie = _repo.GetById(id);

            if (movie == null)
                throw new Exception("NotFound");

            _repo.Delete(id);
        }
    }
}
