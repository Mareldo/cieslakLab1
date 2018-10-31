using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cieslakLab1.Model
{
    public interface IUnitOfWork
    {
        int SaveChanges();
    }
}
