namespace RestauranteAPI.Domain.Entities
{
    public class Table
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Status { get; set; } = "fechada";

        // 🔑 Relação 1:N -> Uma mesa pode ter vários pedidos
        public ICollection<Order> Orders { get; set; } = new List<Order>();

        // Propriedade de conveniência
        public bool IsOpen => Status == "aberta";

        public Table() { }

        public Table(int number, string status = "aberta")
        {
            Number = number;
            Status = status;
        }
    }
}
