using cieslakLab1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cieslakLab1.Infrastructure
{
    public class AuthorRepository : IRepository<Author>
    {
        BookstoreContext _db;
        public IUnitOfWork UnitOfWork => _db;

        public AuthorRepository(BookstoreContext db)
        {
            _db = db;
        }

        public IEnumerable<Author> GetAll()
        {
            return _db.Authors.ToList();
        }

        public Author FindById(int id)
        {
            return _db.Authors.Find(id);
        }

        public void Insert(Author author)
        {
            _db.Authors.Add(author);
        }

        public void Update(Author author)
        {   
            _db.Update(author);
        }

        public void Delete(int id)
        {
            var author = FindById(id);

            if(author != null)
            {
                _db.Authors.Remove(author);
            }
        }
    }
}
