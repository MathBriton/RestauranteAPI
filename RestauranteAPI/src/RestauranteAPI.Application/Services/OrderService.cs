using RestauranteAPI.Application.Interfaces;
using RestauranteAPI.Domain.Entities;
using RestauranteAPI.Domain.Repositories;

namespace RestauranteAPI.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ITableRepository _tableRepository;
        private readonly IProductRepository _productRepository;

        public OrderService(
            IOrderRepository orderRepository,
            ITableRepository tableRepository,
            IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _tableRepository = tableRepository;
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Order>> GetAllOrderAsync()
        {
            return await _orderRepository.GetAllAsync();
        }

        public async Task<Order> CreateOrderAsync(int tableId)
        {
            var table = await _tableRepository.GetByIdAsync(tableId);
            if (table is null)
                throw new InvalidOperationException("Mesa não encontrada.");

            // Se você usa Status/IsOpen na entidade Table:
            // Garanta que só cria pedido se a mesa estiver aberta
            if (!(table.Status?.ToLower() == "aberta" || table.IsOpen))
                throw new InvalidOperationException("Mesa fechada. Abra a mesa antes de criar o pedido.");

            var order = new Order(tableId);
            await _orderRepository.AddAsync(order);
            return order;
        }

        public async Task AddItemToOrderAsync(int orderId, int productId, int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantidade deve ser maior que zero.", nameof(quantity));

            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order is null)
                throw new InvalidOperationException("Pedido não encontrado.");

            if (order.IsClosed)
                throw new InvalidOperationException("Pedido já está fechado.");

            var product = await _productRepository.GetByIdAsync(productId);
            if (product is null)
                throw new InvalidOperationException("Produto não encontrado.");

            // Você pode ter um método de domínio order.AddItem(product, quantity).
            // Se existir, prefira ele. Aqui vamos adicionar direto na coleção:
            var item = new OrderItem(order.Id, product.Id, quantity);
            order.Items.Add(item);

            await _orderRepository.UpdateAsync(order);
        }

        public async Task CloseOrderAsync(int orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order is null)
                throw new InvalidOperationException("Pedido não encontrado.");

            if (order.IsClosed)
                return; // idempotente

            order.IsClosed = true;
            await _orderRepository.UpdateAsync(order);
        }
    }
}
