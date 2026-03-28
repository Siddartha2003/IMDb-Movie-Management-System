using IMDb_Movie_Management_System.Models.DB;
using IMDb_Movie_Management_System.Models.Request;
using IMDb_Movie_Management_System.Models.Response;
using IMDb_Movie_Management_System.Repositories.Interfaces;
using IMDb_Movie_Management_System.Services.Interfaces;

namespace IMDb_Movie_Management_System.Services.Implementations
{
    public class ProducerService : IProducerService
    {
        private readonly IProducerRepository _repo;

        public ProducerService(IProducerRepository repo)
        {
            _repo = repo;
        }

        public List<ProducerResponse> Get()
        {
            return _repo.GetAll().Select(p => new ProducerResponse
            {
                Id = p.Id,
                Name = p.Name
            }).ToList();
        }

        public ProducerResponse Get(int id)
        {
            var producer = _repo.GetById(id);

            if (producer == null)
                throw new Exception("NotFound");

            return new ProducerResponse
            {
                Id = producer.Id,
                Name = producer.Name
            };
        }

        public void Create(ProducerRequest request)
        {
            if (string.IsNullOrEmpty(request.Name))
                throw new Exception("Name required");

            _repo.Add(new Producer
            {
                Name = request.Name,
                Bio = request.Bio,
                DOB = request.DOB,
                Gender = request.Gender
            });
        }

        public void Update(int id, ProducerRequest request)
        {
            var producer = _repo.GetById(id);

            if (producer == null)
                throw new Exception("NotFound");

            producer.Name = request.Name;
            producer.Bio = request.Bio;
            producer.DOB = request.DOB;
            producer.Gender = request.Gender;

            _repo.Update(producer);
        }

        public void Delete(int id)
        {
            if (_repo.GetById(id) == null)
                throw new Exception("NotFound");

            _repo.Delete(id);
        }
    }
}
