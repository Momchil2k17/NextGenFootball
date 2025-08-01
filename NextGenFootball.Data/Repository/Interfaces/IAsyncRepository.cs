using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Data.Repository.Interfaces
{
    public interface IAsyncRepository<TEntity, TKey>
    {
        ValueTask<TEntity?> GetByIdAsync(TKey id);

        Task<TEntity?> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<int> CountAsync();

        Task AddAsync(TEntity item);

        Task AddRangeAsync(IEnumerable<TEntity> items);

        Task<bool> DeleteAsync(TEntity entity);

        Task<bool> HardDeleteAsync(TEntity entity);

        Task<bool> UpdateAsync(TEntity item);

        Task SaveChangesAsync();
        Task<bool> AnyAsync();
    }
}
