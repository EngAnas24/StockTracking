using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StockTracking.Models.DTOs
{
    public class WarehouseDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Warehouse name is required.")]
        [StringLength(100, ErrorMessage = "Warehouse name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [StringLength(200, ErrorMessage = "Location cannot exceed 200 characters.")]
        public string? Location { get; set; }

        [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters.")]
        public string? Description { get; set; }
      
    }
}
