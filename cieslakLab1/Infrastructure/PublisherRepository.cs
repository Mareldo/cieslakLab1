using cieslakLab1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cieslakLab1.Infrastructure
{
    public class PublisherRepository : IRepository<Publisher>
    {
        BookstoreContext _db;
        public IUnitOfWork UnitOfWork => _db;

        public PublisherRepository(BookstoreContext db)
        {
            _db = db;
        }

        public IEnumerable<Publisher> GetAll()
        {
            return _db.Publishers.ToList();
        }

        public Publisher FindById(int id)
        {
            return _db.Publishers.Find(id);
        }

        public void Insert(Publisher publisher)
        {
            _db.Publishers.Add(publisher);
        }

        public void Update(Publisher publisher)
        {
            _db.Update(publisher);
        }

        public void Delete(int id)
        {
            var publisher = FindById(id);

            if (publisher != null)
            {
                _db.Publishers.Remove(publisher);
            }
        }
    }
}
