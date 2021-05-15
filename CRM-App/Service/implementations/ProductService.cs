using CRM_App.Database;
using CRM_App.Model;
using CRM_App.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_App.Service.implementations
{
    public class ProductService : IProductService
    {
        private CrmDbContext db;

        public ProductService(CrmDbContext _db)
        {
            db = _db;
        }
        public OptionProduct CreateProduct(OptionProduct optionProduct)
        { //validation of the customer first
            if (optionProduct == null)
            {
                return null;
            }
            if (optionProduct.Name == null)
            {
                return null;
            }
            Product product = optionProduct.GetProduct();
            db.Products.Add(product);
            db.SaveChanges();
            return new OptionProduct(product);

        }
    }
}
