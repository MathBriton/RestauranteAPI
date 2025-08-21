using RestauranteAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteAPI.Domain.Repositories
{
    public interface ITableRepository
    {
        Task<Table?> GetByIdAsync (int id);
        Task<IEnumerable<Table>> GetAllAsync();
        Task AddAsync(Table table);
        Task UpdateAsync (Table table);
        Task DeleteAsync(int id);
    }
}
