using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MassageSalon.DAL.Common.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(int id);
        IEnumerable<TEntity> Find(Func<TEntity, bool> predicate);
        Task CreateAsync(TEntity item);
        Task UpdateAsync(TEntity item);
        Task DeleteAsync(int id);    
        IEnumerable<TEntity> GetWithInclude(params Expression<Func<TEntity, object>>[] includeProperties);
        public Task<int> GetCountAsync();
        public IEnumerable<TEntity> GetRange(int skipPos = 0, int count = 3);
    }
}
