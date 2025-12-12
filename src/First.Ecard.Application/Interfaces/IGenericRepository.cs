using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.Ecard.Domain.Common;
using First.Ecard.Domain.Entities;

namespace First.Ecard.Application.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> CreateAsync(T entity);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<Agent> GetByEmailAsync(string email);
        Task<T> UpdateAsync(T entity);
        Task Delete(T entity);
    }
}