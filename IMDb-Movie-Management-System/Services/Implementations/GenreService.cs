using IMDb_Movie_Management_System.Models.DB;
using IMDb_Movie_Management_System.Models.Request;
using IMDb_Movie_Management_System.Models.Response;
using IMDb_Movie_Management_System.Repositories.Interfaces;
using IMDb_Movie_Management_System.Services.Interfaces;

namespace IMDb_Movie_Management_System.Services.Implementations
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _repo;

        public GenreService(IGenreRepository repo)
        {
            _repo = repo;
        }

        public List<GenreResponse> Get()
        {
            return _repo.GetAll().Select(g => new GenreResponse
            {
                Id = g.Id,
                Name = g.Name
            }).ToList();
        }

        public GenreResponse Get(int id)
        {
            var genre = _repo.GetById(id);

            if (genre == null)
                throw new Exception("NotFound");

            return new GenreResponse
            {
                Id = genre.Id,
                Name = genre.Name
            };
        }

        public void Create(GenreRequest request)
        {
            if (string.IsNullOrEmpty(request.Name))
                throw new Exception("Name required");

            _repo.Add(new Genre
            {
                Name = request.Name
            });
        }

        public void Update(int id, GenreRequest request)
        {
            var genre = _repo.GetById(id);

            if (genre == null)
                throw new Exception("NotFound");

            genre.Name = request.Name;

            _repo.Update(genre);
        }

        public void Delete(int id)
        {
            if (_repo.GetById(id) == null)
                throw new Exception("NotFound");

            _repo.Delete(id);
        }
    }
}
