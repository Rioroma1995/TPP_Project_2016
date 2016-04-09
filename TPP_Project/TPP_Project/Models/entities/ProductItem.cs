using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPP_Project.Models.enums;

namespace TPP_Project.Models.entities
{
    [Bind(Exclude = "ID")]
    public class ProductItem
    {
        [Key]
        [ScaffoldColumn(false)]
        public int ID { get; set; }
        [Required(ErrorMessage = "An Item Name is required")]
        [StringLength(160)]
        public string Name { get; set; }
        public String shortDescription { get; set; }
        public String description { get; set; }
        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, 999999.99, ErrorMessage = "Price must be between 0.01 and 999999.99")]
        public decimal Price { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
        public TemplateSiteTypes Categorie { get; set; }

        public String toString()
        {
            return Name + " " + Price + " " + description;
        }
    }

}