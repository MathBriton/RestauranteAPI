using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteAPI.Application.DTOs
{
    public class TableDto
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Status { get; set; } = "fechada";
    }
}
