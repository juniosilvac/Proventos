using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Proventos.Core.Interfaces
{
    public interface IRepository<T> : IDisposable where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> FindWhereAsync(Expression<Func<T, bool>> predicate);
    }
}