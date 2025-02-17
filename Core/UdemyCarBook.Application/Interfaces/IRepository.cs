using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);

        Task CreatedAsync(T entity);
        Task UpdatedAsync(T entity);
        Task RemoveAsync(T entity);
        Task<T?> GetByFilterAsync (Expression<Func<T,bool>>filter);
    }
}
