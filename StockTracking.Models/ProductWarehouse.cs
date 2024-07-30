using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace StockTracking.Models
{
    public class ProductWarehouse
    {
        public int Id { get; set; }
        public int ProductId { get; set; } 
        public int WarehouseId { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Warehouse Warehouse { get; set; } // Lazy-loaded
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Product Product { get; set; } // Lazy-loaded
    [Range(0, int.MaxValue, ErrorMessage = "Quantity must be a non-negative number.")]
        public int Quantity { get; set; }
    }
}
