using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteAPI.Domain.Entities
{
    public class Table
    {
        public int Id { get; private set; }
        public int Number { get; private set; }
        public bool IsOpen { get; private set; }

        private readonly List<Order> _orders = new();
        public IReadOnlyCollection<Order> Orders => _orders.AsReadOnly();

        private Table () { } // EF Core Precisa

        public Table (int number)
        {
            Number = number;
            IsOpen = true;
        }
        
        public void CloseTable()
        {
            IsOpen = false;
        }

        public void OpenTable()
        {
            IsOpen = true;
        }
    }
}
