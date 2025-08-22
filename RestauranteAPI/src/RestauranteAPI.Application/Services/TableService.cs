using RestauranteAPI.Application.Interfaces;
using RestauranteAPI.Domain.Entities;
using RestauranteAPI.Domain.Repositories;

namespace RestauranteAPI.Application.Services
{
    public class TableService : ITableService
    {
        private readonly ITableRepository _tableRepository;

        public TableService(ITableRepository tableRepository)
        {
            _tableRepository = tableRepository;
        }

        public async Task<IEnumerable<Table>> GetAllTablesAsync()
        {
            return await _tableRepository.GetAllAsync();
        }

        public async Task<Table> OpenTableAsync(int number)
        {
            var table = new Table(number, "aberta");
            await _tableRepository.AddAsync(table);
            return table;
        }

        public async Task CloseTableAsync(int id)
        {
            var table = await _tableRepository.GetByIdAsync(id);
            if (table != null)
            {
                table.Status = "fechada";
                await _tableRepository.UpdateAsync(table);
            }
        }
    }
}
