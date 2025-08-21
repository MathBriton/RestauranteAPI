using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteAPI.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        private Product () { } // EF Core Precisa

        public Product (string name, decimal price)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Nome do produto é obrigatório.");
            if (price < 0)
                throw new ArgumentException("Preço do produto não pode ser negativo.");

            Name = name;
            Price = price;
        }

        public void UpdatePrice (decimal newPrice)
        {
            if (newPrice < 0) throw new ArgumentException("Preço não pode ser negativo.");
            Price = newPrice;
        }

        public void UpdateName (string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
                throw new ArgumentException("Nome do produto é obrigatório.");
            Name = newName;
        }
    }
}
