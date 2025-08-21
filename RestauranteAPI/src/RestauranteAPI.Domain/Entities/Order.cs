using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteAPI.Domain.Entities;

public class Order
{
    public int Id { get; private set; }
    public int TableId { get; private set; }
    public Table Table { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public bool IsClosed { get; private set; }

    private readonly List<OrderItem> _items = new();
    public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();

    private Order() { } // EF Core

    public Order(int tableId)
    {
        TableId = tableId;
        IsClosed = false;
    }

    public void AddItem(Product product, int quantity)
    {
        if (IsClosed) throw new InvalidOperationException("Não é possível adicionar itens a um pedido fechado.");
        if (quantity <= 0) throw new ArgumentException("Quantidade deve ser maior que zero.");

        var item = new OrderItem(Id, product.Id, product.Price, quantity);
        _items.Add(item);
    }

    public decimal GetTotal() => _items.Sum(i => i.GetTotal());

    public void Close()
    {
        IsClosed = true;
    }
}