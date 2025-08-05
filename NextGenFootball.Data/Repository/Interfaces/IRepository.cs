using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Data.Repository.Interfaces
{
    public interface IRepository<TEntity, TKey>
    {
        TEntity? GetById(TKey id);

        TEntity? SingleOrDefault(Func<TEntity, bool> predicate);

        TEntity? FirstOrDefault(Func<TEntity, bool> predicate);

        IEnumerable<TEntity> GetAll();

        int Count();

        IQueryable<TEntity> GetAllAttached();

        void Add(TEntity item);

        void AddRange(IEnumerable<TEntity> items);
        void RemoveRange(IEnumerable<TEntity> items);

        bool Delete(TEntity entity);

        bool HardDelete(TEntity entity);

        bool Update(TEntity item);

        void SaveChanges();
    }
}
