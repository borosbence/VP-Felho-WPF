using System.Collections.Generic;

namespace VP_Felho.Repositories
{
    public interface IGenericRepository<T> where T: class
    {
        List<T> GetAll();
        T Get(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
