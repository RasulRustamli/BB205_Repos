using BB205_test.Entities.Base;
using System.Linq.Expressions;

namespace BB205_test.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        
        Task<IQueryable<T>> GetAll(Expression<Func<T, bool>>? expression= null,Expression<Func<T, object>> ? orderbyExpression = null,
bool isDescending = false, params string[] includes);
        Task<T> GetByIdAsync(int id);
        Task Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task SaveChangesAsync();


    }
}
