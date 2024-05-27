using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models.EntityModels
{
    public class Order
    {
        public Guid Id { get; set; }

        public string ShippingAddress { get; set; }
        public string Status { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }

        [ForeignKey("ApplicationUser")]
        public string? UserId { get; set; }
        [ForeignKey("Product")]
        public Guid? ProductId { get; set; }
        public ApplicationUser? User { get; set; }
        public Product? Product { get; set; }
    }
}
