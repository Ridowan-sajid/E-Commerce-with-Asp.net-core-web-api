using ECommerce.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ECommerce.Models.DtoModels
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public Guid ProductId { get; set; }
        public string ShippingAddress { get; set; }
        public string Status { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}
