using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StockTracking.Models
{
    public class ProductSuppliers
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Product? product { get; set; }
        public int SuppliersId { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Suppliers ? Suppliers { get; set; }
    }
}
