using LiveLarn.Core.DataAccess;
using LiveLarn.Core.Infrastructure.Abstract.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Koton.ArthurService.Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity> where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public TEntity Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
                return entity;
            }
        }
        public TContext Context()
        {
            return new TContext();
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                await context.SaveChangesAsync();
                return entity;
            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public async Task DeleteAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                await context.SaveChangesAsync();
            }
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }


        public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null, params string[] keys)
        {
            using (var context = new TContext())
            {
                var result = filter == null ? context.Set<TEntity>() : context.Set<TEntity>().Where(filter);

                if (keys != null)
                {
                    foreach (string key in keys)
                    {
                        result.Include(key);
                    }
                }

                return await result.ToListAsync();
            }
        }


        public TEntity GetT(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }


        public async Task<TEntity> GetTAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return await context.Set<TEntity>().SingleOrDefaultAsync(filter);
            }
        }

        public TEntity Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var UpdatetedEntity = context.Entry(entity);
                UpdatetedEntity.State = EntityState.Modified;
                context.SaveChanges();
                return entity;
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                var UpdatetedEntity = context.Entry(entity);
                UpdatetedEntity.State = EntityState.Modified;
                await context.SaveChangesAsync();
                return entity;
            }
        }
        public async Task<List<TEntity>> Include(Expression<Func<TEntity, bool>> filter = null, IEnumerable<Expression<Func<TEntity, bool>>> foreignKeys = null)
        {
            using (var context = new TContext())
            {
                var result = context.Set<TEntity>().Where(filter);
                foreach (Expression<Func<TEntity, bool>> key in foreignKeys)
                {
                    result.Include(key);
                }

                return await result.ToListAsync();
            }
        }
    }
}
