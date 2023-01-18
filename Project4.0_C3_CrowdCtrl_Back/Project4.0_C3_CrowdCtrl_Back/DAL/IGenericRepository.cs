using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project4._0_C3_CrowdCtrl_Back.DAL
{
    public interface IGenericRepository<T>
    {
        Task<T> GetAsync(long id);
        T? Get(long id);
        Task<IEnumerable<T>> AllAsync();
        IQueryable<T> AllQuery();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> filter);
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            params Expression<Func<T, object>>[] includes);
        void Delete(T entity);
        T Add(T entity);
    }
}
