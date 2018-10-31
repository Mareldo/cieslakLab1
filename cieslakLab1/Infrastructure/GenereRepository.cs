using cieslakLab1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cieslakLab1.Infrastructure
{
    public class GenereRepository : IRepository<Genere>
    {
        BookstoreContext _db;
        public IUnitOfWork UnitOfWork => _db;

        public GenereRepository(BookstoreContext db)
        {
            _db = db;
        }

        public IEnumerable<Genere> GetAll()
        {
            return _db.Generes.ToList();
        }

        public Genere FindById(int id)
        {
            return _db.Generes.Find(id);
        }

        public void Insert(Genere genere)
        {
            _db.Generes.Add(genere);
        }

        public void Update(Genere genere)
        {
            _db.Update(genere);
        }

        public void Delete(int id)
        {
            var genere = FindById(id);

            if (genere != null)
            {
                _db.Generes.Remove(genere);
            }
        }
    }
}
