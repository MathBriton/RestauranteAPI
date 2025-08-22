namespace RestauranteAPI.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int TableId { get; set; }

        // Propriedade de navegação
        public Table Table { get; set; }

        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
        public bool IsClosed { get; set; } = false;

        // Construtor protegido para EF Core
        protected Order() { }

        // Construtor público com tableId para uso no código
        public Order(int tableId)
        {
            TableId = tableId;
        }

        // Método de domínio para adicionar item
        public void AddItem(Product product, int quantity)
        {
            if (IsClosed)
                throw new InvalidOperationException("Pedido fechado não pode receber itens.");
            if (quantity <= 0)
                throw new ArgumentException("Quantidade deve ser maior que zero.");

            Items.Add(new OrderItem(this.Id, product.Id, quantity));
        }

        // Método de domínio para fechar pedido
        public void Close()
        {
            IsClosed = true;
        }
    }
}
