using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryInfrastructure.Data.IRepository
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
