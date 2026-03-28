using IMDb_Movie_Management_System.Models.Request;
using IMDb_Movie_Management_System.Models.Response;

namespace IMDb_Movie_Management_System.Services.Interfaces
{
    public interface IActorService
    {
        List<ActorResponse> Get();
        ActorResponse Get(int id);
        void Create(ActorRequest request);
        void Update(int id, ActorRequest request);
        void Delete(int id);
    }
}
