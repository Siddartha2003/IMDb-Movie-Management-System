using IMDb_Movie_Management_System.Models.DB;
using IMDb_Movie_Management_System.Models.Request;
using IMDb_Movie_Management_System.Models.Response;
using IMDb_Movie_Management_System.Repositories.Interfaces;
using IMDb_Movie_Management_System.Services.Interfaces;

namespace IMDb_Movie_Management_System.Services.Implementations
{
    public class ActorService : IActorService
    {
        private readonly IActorRepository _repo;

        public ActorService(IActorRepository repo)
        {
            _repo = repo;
        }

        public List<ActorResponse> Get()
        {
            return _repo.GetAll().Select(a => new ActorResponse
            {
                Id = a.Id,
                Name = a.Name
            }).ToList();
        }

        public ActorResponse Get(int id)
        {
            var actor = _repo.GetById(id);

            if (actor == null)
                throw new Exception("NotFound");

            return new ActorResponse
            {
                Id = actor.Id,
                Name = actor.Name
            };
        }

        public void Create(ActorRequest request)
        {
            if (string.IsNullOrEmpty(request.Name))
                throw new Exception("Name required");

            _repo.Add(new Actor
            {
                Name = request.Name,
                Bio = request.Bio,
                DOB = request.DOB,
                Gender = request.Gender
            });
        }

        public void Update(int id, ActorRequest request)
        {
            var actor = _repo.GetById(id);

            if (actor == null)
                throw new Exception("NotFound");

            actor.Name = request.Name;
            actor.Bio = request.Bio;
            actor.DOB = request.DOB;
            actor.Gender = request.Gender;

            _repo.Update(actor);
        }

        public void Delete(int id)
        {
            if (_repo.GetById(id) == null)
                throw new Exception("NotFound");

            _repo.Delete(id);
        }
    }
}
