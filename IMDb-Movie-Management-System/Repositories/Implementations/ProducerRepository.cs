using IMDb_Movie_Management_System.Models.DB;
using IMDb_Movie_Management_System.Repositories.Interfaces;

namespace IMDb_Movie_Management_System.Repositories.Implementations
{
    public class ProducerRepository : IProducerRepository
    {
        private static List<Producer> _producers = new List<Producer>();

        public List<Producer> GetAll()
        {
            return _producers;
        }

        public Producer GetById(int id)
        {
            return _producers.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Producer producer)
        {
            producer.Id = _producers.Count + 1;
            _producers.Add(producer);
        }

        public void Update(Producer producer)
        {
            var existing = GetById(producer.Id);

            if (existing != null)
            {
                existing.Name = producer.Name;
                existing.Bio = producer.Bio;
                existing.DOB = producer.DOB;
                existing.Gender = producer.Gender;
            }
        }

        public void Delete(int id)
        {
            var producer = GetById(id);

            if (producer != null)
            {
                _producers.Remove(producer);
            }
        }
    }
}
