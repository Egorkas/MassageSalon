using System;
using System.Collections.Generic;
using System.Text;

namespace MassageSalon.DAL.Common.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(int? id);
        IEnumerable<TEntity> Find(Func<TEntity, bool> predicate);
        void Create(TEntity item);
        void Update(TEntity item);
        void Delete(int id);
    }
}
