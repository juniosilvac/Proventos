using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proventos.Core.Interfaces
{
    public interface IRepository<T> : IDisposable where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
    }
}