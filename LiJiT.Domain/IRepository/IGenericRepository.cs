using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LiJiT.Domain.IRepository
{
    public interface IGenericRepository<TEntity>
        where TEntity : class
    {
        ValueTask<TEntity> GetById(int id);
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Remove(TEntity entity);
        Task<IEnumerable<TEntity>> GetAll();
        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
        Task<int> CountAll();
        void Commit();
        Task CommitAsync();

    }
}
