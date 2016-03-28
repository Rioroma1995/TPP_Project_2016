using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPP_Project.Models
{
    public class Customer : ApplicationUser
    {
        public virtual ICollection<Order> orders { get; set; }
    }
}