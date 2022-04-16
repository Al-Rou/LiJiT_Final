using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LiJiT.Model;
using Microsoft.EntityFrameworkCore;

namespace LiJiT.Domain.IRepository
{
    public abstract class GenericRepository<TEntity, TContext> : IGenericRepository<TEntity>
        where TEntity : BaseEntity, new()
        where TContext : DbContext
    {
        protected TContext Context;

        public GenericRepository(TContext context)
        {
            Context = context;
        }

        public virtual ValueTask<TEntity> GetById(int id)
        {
            return Context.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task Add(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
            await Context.SaveChangesAsync();
        }
        public virtual async Task Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }
        public async Task Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
            await Context.SaveChangesAsync();
        }
        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }
        public IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate).ToList();
        }
        public Task<int> CountAll()
        {
            return Context.Set<TEntity>().CountAsync();
        }
        
       
        public void Commit()
        {
            Context.SaveChanges();
        }
        public async Task CommitAsync()
        {
            await Context.SaveChangesAsync();
        }


    }
}
