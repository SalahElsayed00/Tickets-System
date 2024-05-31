using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.Core.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync(int page = 1, int pageSize = 5);
        Task AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
    }

}
