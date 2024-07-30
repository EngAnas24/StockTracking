using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
namespace StockTracking.Models.DTOs
{
    public class ProductDTO
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
        public IFormFile? ProductImageFile { get; set; }

        [StringLength(50, ErrorMessage = "The SKU cannot exceed 50 characters.")]
        public string? SKU { get; set; }
        [DataType(DataType.Date)]
        public DateTime? AddedDate { get; set; }

        public int? CategoryId { get; set; }
        public  ICollection<ProductWarehouseDTO>? ProductWarehouses { get; set; } = new List<ProductWarehouseDTO>();
        public  ICollection<ProductSuppliersDTO>? ProductSuppliers { get; set; }= new List<ProductSuppliersDTO>();

    }

}



