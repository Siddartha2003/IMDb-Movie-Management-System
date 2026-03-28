using IMDb_Movie_Management_System.Models.DB;

namespace IMDb_Movie_Management_System.Repositories.Interfaces
{
    public interface IActorRepository
    {
        List<Actor> GetAll();
        Actor GetById(int id);
        void Add(Actor actor);
        void Update(Actor actor);
        void Delete(int id);
    }
}
