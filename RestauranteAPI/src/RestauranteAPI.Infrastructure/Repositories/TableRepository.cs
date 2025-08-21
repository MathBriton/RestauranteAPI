using Microsoft.EntityFrameworkCore;
using RestauranteAPI.Domain.Entities;
using RestauranteAPI.Domain.Repositories;
using RestauranteAPI.Infrastructure.Context;

namespace RestauranteAPI.Infrastructure.Repositories;

public class TableRepository : ITableRepository
{
    private readonly RestauranteContext _context;

    public TableRepository(RestauranteContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Table table)
    {
        await _context.Tables.AddAsync(table);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var table = await _context.Tables.FindAsync(id);
        if (table != null)
        {
            _context.Tables.Remove(table);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Table>> GetAllAsync()
    {
        return await _context.Tables.Include(t => t.Orders).ToListAsync();
    }

    public async Task<Table?> GetByIdAsync(int id)
    {
        return await _context.Tables.Include(t => t.Orders)
                                    .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task UpdateAsync(Table table)
    {
        _context.Tables.Update(table);
        await _context.SaveChangesAsync();
    }
}
