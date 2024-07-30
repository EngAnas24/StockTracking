using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StockTracking.Models
{
    public class Suppliers
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [StringLength(200, ErrorMessage = "Contact information cannot exceed 200 characters.")]
        public string? ContactInformation { get; set; }

        public virtual ICollection<ProductSuppliers>? ProductSuppliers { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<Transactions>? Transactions { get; set; }


    }
}
