using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace TPP_Project.Models
{
    [Bind(Exclude = "OrderId")]
    public class Order
    {
        [ScaffoldColumn(false)]
        public int OrderId { get; set; }
        [ScaffoldColumn(false)]
        public DateTime OrderDate { get; set; }
        public DateTime completeDate { get; set; }
        public OrderStatus orderStartus { get; set; }
        public virtual ICollection<ProductItem> orderItems { get; set; }
        public String detailDescription { get; set; }
        [ScaffoldColumn(false)]
        public decimal Total { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public Customer customer { get; set; }
        public bool SaveInfo { get; set; }

    }

}