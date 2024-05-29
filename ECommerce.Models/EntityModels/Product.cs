using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
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
        public string? Category { get; set; }
        public string? Color { get; set; }
        public string? Size { get; set; }
        [ValidateNever]
        public ICollection<Order> Orders { get; set; } = new List<Order>();//So that when we try to create Product we dont need to create order.

    }
}
