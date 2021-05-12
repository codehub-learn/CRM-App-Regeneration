using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_App.Model
{
    public class Product
    {
        public int ProductId { get; set; }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime RegistrationDate { get; set; }
        public decimal SupplierPrice { get; set; }
        public decimal Discount { get; set; }
        public int InventoryQuantity { get; set; }
        public decimal VatValue { get; set; }

        public List<OrderProduct> OrderProducts { get; set; }

        public Supplier Supplier { get; set; }

    }
}
