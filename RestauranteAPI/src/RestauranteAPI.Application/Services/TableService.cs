using RestauranteAPI.Application.DTOs;
using RestauranteAPI.Domain.Entities;
using RestauranteAPI.Domain.Interfaces;
using RestauranteAPI.Domain.Repositories;

namespace RestauranteAPI.Application.Services
{
    public class TableService
    {
        private readonly ITableRepository _repository;

        public TableService(ITableRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TableDto>> GetAllAsync()
        {
            var tables = await _repository.GetAllAsync();
            return tables.Select(t => new TableDto
            {
                Id = t.Id,
                Number = t.Number,
                Status = t.Status
            });
        }

        public async Task<TableDto> CreateAsync(TableDto dto)
        {
            var table = new Table(dto.Number, dto.Status);
            await _repository.AddAsync(table);

            return new TableDto
            {
                Id = table.Id,
                Number = table.Number,
                Status = table.Status
            };
        }
    }
}
