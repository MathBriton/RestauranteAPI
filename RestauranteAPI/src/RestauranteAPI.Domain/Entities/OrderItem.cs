namespace RestauranteAPI.Domain.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }   // chave estrangeira
        public int ProductId { get; set; } // chave estrangeira
        public int Quantity { get; set; }

        // ✅ Propriedades de navegação
        public Order? Order { get; set; }
        public Product? Product { get; set; }

        // Construtor
        public OrderItem() { }

        public OrderItem(int orderId, int productId, int quantity)
        {
            OrderId = orderId;
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
