using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFProfExample.Models;

namespace EFProfExample.Repositories
{
    public interface IRepository<T> where T : BaseModel, new()
    {
        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Delete(int id);

        T GetById(int id);

        IEnumerable<T> GetAllActive();

        IEnumerable<T> GetAllActive(int page, int pageSize);

        IEnumerable<T> GetAll();

        void SaveChanges();
    }
}
