using ECommerce.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models.DtoModels
{
    public class RegisterCustomerDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Address { get; set; }
        public string? PurchaseHistory { get; set; }
        public string? Preferences { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public List<string> Roles { get; set; }

        //public ICollection<Order> Orders { get; set; } = new List<Order>();

    }
}
