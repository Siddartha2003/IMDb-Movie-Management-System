using IMDb_Movie_Management_System.Models.DB;
using IMDb_Movie_Management_System.Repositories.Interfaces;

namespace IMDb_Movie_Management_System.Repositories.Implementations
{
    public class ActorRepository : IActorRepository
    {
        private static List<Actor> _actors = new List<Actor>();

        public List<Actor> GetAll()
        {
            return _actors;
        }

        public Actor GetById(int id)
        {
            return _actors.FirstOrDefault(a => a.Id == id);
        }

        public void Add(Actor actor)
        {
            actor.Id = _actors.Count + 1;
            _actors.Add(actor);
        }

        public void Update(Actor actor)
        {
            var existing = GetById(actor.Id);

            if (existing != null)
            {
                existing.Name = actor.Name;
                existing.Bio = actor.Bio;
                existing.DOB = actor.DOB;
                existing.Gender = actor.Gender;
            }
        }

        public void Delete(int id)
        {
            var actor = GetById(id);

            if (actor != null)
            {
                _actors.Remove(actor);
            }
        }
    }
}

