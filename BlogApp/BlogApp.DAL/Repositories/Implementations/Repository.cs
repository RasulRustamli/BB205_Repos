using BlogApp.Core.Entities.Common;
using BlogApp.DAL.Context;
using BlogApp.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DAL.Repositories.Implementations
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }
        public DbSet<TEntity> Table => _context.Set<TEntity>();

      

        public async Task<IQueryable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? expression = null,
            Expression<Func<TEntity, object>>? orderbyExpression = null,
            bool isDescending = false
            , params string[] includes)
        {
            IQueryable<TEntity> query = Table.Where(e=>!e.IsDeleted);

            if (expression is not null)
            {
                query = query.Where(expression);
            }
            if (orderbyExpression != null)
            {
                query = isDescending ? query.OrderByDescending(orderbyExpression)
                    : query.OrderBy(orderbyExpression);
            }
            if (includes is not null)
            {
                for (int i = 0; i < includes.Length; i++)
                {
                    query = query.Include(includes[i]);
                }
            }
            return query;
        }
        public async Task CreateAsync(TEntity entity)
        {
          await  Table.AddAsync(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<TEntity> FindById(int id,bool isDelete=false, params string[] includes)
        {
            IQueryable<TEntity> query = Table.Where(c=>c.Id==id&&c.IsDeleted==isDelete);
            if (includes is not null&&query.Count()>0)
            {
                for (int i = 0; i < includes.Length; i++)
                {
                    query = query.Include(includes[i]);
                }
            }
            
            var entity = await query.FirstOrDefaultAsync();
            return entity;
        }

        public async Task<bool> IsExist(int id)
        {
           return await Table.AnyAsync(e => e.Id == id && !e.IsDeleted);
        }

        public async Task Remove(int id)
        {
            Table.Remove(await FindById(id));
        }

        public async Task SoftDelete(int id)
        {
            (await FindById(id)).IsDeleted = true;
        }

        public async Task ReverseSoftDelete(int id)
        {
            (await FindById(id,true)).IsDeleted =false;
        }
    }
}
