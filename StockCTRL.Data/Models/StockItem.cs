using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockCTRL.Data.Models
{
    public class StockItem
    {
        public int Id { get; set; }
        [Required]
        public string Sku { get; set; }
        [Required]
        public string ItemName { get; set; }
        public ItemType ItemType { get; set; }
        [Required]
        public string Description { get; set; }
        public bool IsAvailable { get; set; }
        public int Quantity { get; set; }
        public double BuyPrice { get; set; }
        public double SellPrice { get; set; }
        public ItemLocation ItemLocation { get; set; }
        public DateTime CreatedDateTime { get; set; }

    }
}
