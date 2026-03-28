using IMDb_Movie_Management_System.Models.DB;

namespace IMDb_Movie_Management_System.Repositories.Interfaces
{
    public interface IProducerRepository
    {
        List<Producer> GetAll();
        Producer GetById(int id);
        void Add(Producer producer);
        void Update(Producer producer);
        void Delete(int id);
    }
}
