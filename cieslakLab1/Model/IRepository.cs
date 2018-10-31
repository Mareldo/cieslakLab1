using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cieslakLab1.Model
{
    public interface IRepository<T>
    {
        IUnitOfWork UnitOfWork { get; }
        IEnumerable<T> GetAll();
        T FindById(int id);
        void Insert(T value);
        void Update(T value);
        void Delete(int id);
    }
}
