using LiveLarn.Core.Infrastructure.Abstract.Base;
using LiveLarn.Core.Infrastructure.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LiveLarn.Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        T GetT(Expression<Func<T, bool>> filter = null);
        Task<T> GetTAsync(Expression<Func<T, bool>> filter = null);
        List<T> GetList(Expression<Func<T, bool>> filter = null);
        Task<List<T>> GetListAsync(Expression<Func<T, bool>> filter = null, params string[] keys);
        T Add(T entity);
        Task<T> AddAsync(T entity);
        T Update(T entity);
        Task<T> UpdateAsync(T entity);
        Task<List<T>> Include(Expression<Func<T, bool>> filter = null, IEnumerable<Expression<Func<T, bool>>> foreignKeys = null);
        void Delete(T entity);
        Task DeleteAsync(T entity);
    }
}
