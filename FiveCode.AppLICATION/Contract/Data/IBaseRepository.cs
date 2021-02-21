using System.Collections.Generic;
using System.Threading.Tasks;

namespace FiveCode.Application.Contract.Data
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);

        Task<IReadOnlyList<T>> ListAllAsync();

        Task<T> AddAsync(T entity);

        void UpdateAsync(T entity);

        void DeleteAsync(T entity);
    }
}