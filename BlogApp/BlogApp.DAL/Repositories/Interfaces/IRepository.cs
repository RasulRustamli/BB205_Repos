using BlogApp.Core.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DAL.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity,new ()
    {
        DbSet<TEntity> Table { get;}
        Task<IQueryable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? expression = null,
            Expression<Func<TEntity, object>>? orderbyExpression = null,
            bool isDescending = false
            , params string[] includes);

        Task CreateAsync(TEntity entity);
        Task<TEntity> FindById(int id);
        Task<bool> IsExist(int id);
        Task<int> SaveChangesAsync();
        Task Remove(int id);
    }
}
