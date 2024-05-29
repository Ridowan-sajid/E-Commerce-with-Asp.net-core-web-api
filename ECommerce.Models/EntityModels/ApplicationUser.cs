//using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models.EntityModels
{
    public class ApplicationUser: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Address { get; set; }
        public string? PurchaseHistory { get; set; }
        public string? Preferences { get; set; }
        [ValidateNever]
        public ICollection<Order> Orders { get; set; } = new List<Order>(); //So that when we try to create user we dont need to create order.

    }
}
