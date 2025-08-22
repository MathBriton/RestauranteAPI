using RestauranteAPI.Domain.Entities;

namespace RestauranteAPI.Application.Interfaces
{
    public interface ITableService
    {
        Task<IEnumerable<Table>> GetAllTablesAsync();
        Task<Table> OpenTableAsync(int number);
        Task CloseTableAsync(int id);
    }
}
