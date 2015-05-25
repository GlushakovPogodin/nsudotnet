using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CTNDb;

namespace CTNDAL
{
    public interface IService<T>
    {
        IEnumerable<T> GetAll();

        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);
    }
}
