using IMDb_Movie_Management_System.Models.Request;
using IMDb_Movie_Management_System.Models.Response;

namespace IMDb_Movie_Management_System.Services.Interfaces
{
    public interface IProducerService
    {
        List<ProducerResponse> Get();
        ProducerResponse Get(int id);
        void Create(ProducerRequest request);
        void Update(int id, ProducerRequest request);
        void Delete(int id);
    }
}
