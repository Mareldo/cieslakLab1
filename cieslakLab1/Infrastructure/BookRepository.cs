using cieslakLab1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cieslakLab1.Infrastructure
{
    public class BookRepository : IRepository<Book>
    {
        BookstoreContext _db;
        public IUnitOfWork UnitOfWork => _db;

        public BookRepository(BookstoreContext db)
        {
            _db = db;
        }

        public IEnumerable<Book> GetAll()
        {
            return _db.Books.ToList();
        }

        public Book FindById(int id)
        {
            return _db.Books.Find(id);
        }

        public void Insert(Book book)
        {
            _db.Books.Add(book);
        }

        public void Update(Book book)
        {
            _db.Update(book);
        }

        public void Delete(int id)
        {
            var book = FindById(id);

            if (book != null)
            {
                _db.Books.Remove(book);
            }
        }
    }
}
