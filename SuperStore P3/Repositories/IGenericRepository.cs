using System.Linq.Expressions;

namespace EcoPower_Logistics.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Remove(T entity);
        // implement Update() method
        void Update(T entity);
    }
}