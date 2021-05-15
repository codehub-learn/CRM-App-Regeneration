using CRM_App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_App.Option
{
    public class OptionProduct
    {
        public int ProductId { get; set; }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime RegistrationDate { get; set; }
        public decimal SupplierPrice { get; set; }
        public decimal Discount { get; set; }
        public int InventoryQuantity { get; set; }
        public decimal VatValue { get; set; }

        public OptionProduct() { }
        public OptionProduct(Product product) { 
            if (product != null)
            {
                ProductId = product.ProductId;
                Name = product.Name;
                Price = product.Price;
                RegistrationDate = product.RegistrationDate;
                SupplierPrice = product.SupplierPrice;
                Discount = product.Discount;
                InventoryQuantity = product.InventoryQuantity;
                VatValue = product.VatValue;
            }
        }

        public Product GetProduct()
        {
            return new Product { 
                Name = Name,
                Discount = Discount,
                InventoryQuantity =InventoryQuantity,
                Price = Price,
                RegistrationDate= RegistrationDate,
                SupplierPrice = SupplierPrice,
                VatValue = VatValue,
            };
        }
    }
}
