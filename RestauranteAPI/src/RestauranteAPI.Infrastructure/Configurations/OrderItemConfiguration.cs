using RestauranteAPI.Domain.Entities;

public class OrderItem
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public Order? Order { get; set; }
    public Product? Product { get; set; }

    // Construtor protegido para EF Core
    protected OrderItem() { }

    // Construtor público com 4 argumentos
    public OrderItem(int orderId, int productId, int quantity, decimal price)
    {
        if (quantity <= 0)
            throw new ArgumentException("Quantidade deve ser maior que zero.");
        if (price < 0)
            throw new ArgumentException("Preço não pode ser negativo.");

        OrderId = orderId;
        ProductId = productId;
        Quantity = quantity;
        Price = price;
    }
}
