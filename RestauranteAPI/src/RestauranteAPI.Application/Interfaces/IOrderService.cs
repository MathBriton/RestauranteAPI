using RestauranteAPI.Domain.Entities;

namespace RestauranteAPI.Application.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAllOrderAsync();
        Task<Order> CreateOrderAsync(int tableId);
        Task AddItemToOrderAsync(int orderId, int productId, int quantity);
        Task CloseOrderAsync(int orderId);
    }
}
