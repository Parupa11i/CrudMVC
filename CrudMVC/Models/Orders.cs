using System;
using System.ComponentModel.DataAnnotations;

namespace CrudMVC.Models
{
    public class Orders
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string OrderDesc { get; set; }
        [Required]
        public string SKU { get; set; }
        public string SKUDescr { get; set; }
        public int Qty { get; set; }
        public double LineCost { get; set; }
        public double OrderCost { get; set; }
        public string Status { get; set; }

        public Orders()
        {
        }

    }
}
