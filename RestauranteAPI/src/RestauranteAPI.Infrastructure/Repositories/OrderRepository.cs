using Microsoft.EntityFrameworkCore;
using RestauranteAPI.Domain.Entities;
using RestauranteAPI.Domain.Repositories;
using RestauranteAPI.Infrastructure.Context;

namespace RestauranteAPI.Infrastructure.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly RestauranteContext _context;

    public OrderRepository(RestauranteContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Order order)
    {
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var order = await _context.Orders.FindAsync(id);
        if (order != null)
        {
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        return await _context.Orders
                             .Include(o => o.Items)
                             .Include(o => o.Table)
                             .ToListAsync();
    }

    public async Task<Order?> GetByIdAsync(int id)
    {
        return await _context.Orders
                             .Include(o => o.Items)
                             .Include(o => o.Table)
                             .FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task UpdateAsync(Order order)
    {
        _context.Orders.Update(order);
        await _context.SaveChangesAsync();
    }
}
