using System;
using System.ComponentModel.DataAnnotations;

namespace CrudMVC.Models
{
    public class Products
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string SKU { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        public int AvailableQty { get; set; }

        public Products()
        {
        }
    }
}
