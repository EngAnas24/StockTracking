using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace StockTracking.Models
{
    public enum TransactionType
    {
        IN, // Incoming
        OUT // Outgoing
    }

    public class Transactions
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Product? Product { get; set; }

        public int WarehouseId { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Warehouse? Warehouse { get; set; }

        public TransactionType TransactionType { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be a positive number.")]
        public int Quantity { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Unit price must be a non-negative number.")]
        [DataType(DataType.Currency)]
        public decimal UnitPrice { get; set; }

        public decimal TaxAmount { get; private set; }
        public decimal TotalAmount { get; private set; }

        public int? SuppliersId { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Suppliers? Suppliers { get; set; }


        [Range(0, double.MaxValue, ErrorMessage = "VAT rate must be a non-negative number.")]
        public decimal VATRate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? TransactionDate { get; set; }

        public void CalculateAmounts()
        {
            if (VATRate != null)
            {
                TaxAmount = UnitPrice * Quantity * VATRate;
                TotalAmount = (UnitPrice * Quantity) + TaxAmount;
            }

        }
    }
}
