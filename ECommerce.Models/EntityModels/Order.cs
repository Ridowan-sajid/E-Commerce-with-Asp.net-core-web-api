using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models.EntityModels
{
    public class Order
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public Guid ProductId { get; set; }
        public string ShippingAddress { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }

        public ApplicationUser User { get; set; }
        public Product Product { get; set; }
    }
}
