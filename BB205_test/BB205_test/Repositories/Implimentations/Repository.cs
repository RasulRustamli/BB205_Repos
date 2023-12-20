

using BB205_test.Entities.Base;
using System.Linq.Expressions;

namespace BB205_test.Repositories.Implimentations
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        private DbSet<T> _table;

        public Repository(AppDbContext context)
        {
            _context = context;
            _table =_context.Set<T>();
        }

     

        public async Task<IQueryable<T>> GetAll(Expression<Func<T,bool>>? expression=null,
            Expression<Func<T,object>>? orderbyExpression = null,
            bool isDescending=false
            , params string[] includes)
        {
            IQueryable<T> query = _table;
            
            if (expression is not null)
            {
                query = query.Where(expression);
            }
            if(orderbyExpression !=null)
            {
                query = isDescending ? query.OrderByDescending(orderbyExpression)
                    : query.OrderBy(orderbyExpression);
            }
            if (includes is not null)
            {
                for(int i = 0; i < includes.Length; i++)
                {
                    query = query.Include(includes[i]);
                }
            }
            

            return query;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _table.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);  
        }

        public async Task Create(T entity)
        {
            await _table.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _table.Remove(entity);
        }
        public void Update(T entity)
        {
            _table.Update(entity);

        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

      
    }
}
