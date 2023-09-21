using Data;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Linq.Expressions;

namespace EcoPower_Logistics.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly SuperStoreContext _context = new SuperStoreContext();

        public GenericRepository(SuperStoreContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(entity)} must not be null");
            }
            try
            {
                _context.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved: {ex.Message}");
            }
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                return _context.Set<T>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not retrieve entities: {ex.Message}");
            }
        }

        public void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(entity)} must not be null");
            }
            try
            {
                _context.Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not remove entity: {ex.Message}");
            }
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(entity)} must not be null");
            }
            try
            {
                _context.Update(entity);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception($"Could not update entity: {ex.Message}");
            }
        }
    }
}
