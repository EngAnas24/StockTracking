using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace StockTracking.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The product name is required.")]
        [StringLength(200, ErrorMessage = "The product name cannot exceed 200 characters.")]
        public string Name { get; set; }

        [StringLength(1000, ErrorMessage = "The description cannot exceed 1000 characters.")]
        public string Description { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be a non-negative number.")]
        public int Quantity { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Price must be a non-negative number.")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [StringLength(50, ErrorMessage = "The SKU cannot exceed 50 characters.")]
        public string? SKU { get; set; }

        public byte[]? ProductImage { get; set; }

        [DataType(DataType.Date)]
        public DateTime? AddedDate { get; set; }

        public int? CategoryId { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Category? Category { get; set; }
       
        public virtual ICollection<ProductWarehouse>? ProductWarehouses { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<Transactions>? Transactions { get; set; }
        public virtual ICollection<ProductSuppliers>? ProductSuppliers { get; set; }

    }
}
