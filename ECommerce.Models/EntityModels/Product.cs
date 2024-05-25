using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models.EntityModels
{
    public class Product
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public string? Specificitions { get; set; }
        public string? Images { get; set; }
        public int? Price { get; set; }
        public int? InventoryLevel { get; set; }
        public int? Category { get; set; }
        public int? Color { get; set; }
        public int? Size { get; set; }
    }
}
