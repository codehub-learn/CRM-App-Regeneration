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
    public class OrderService : IOrderService
    {
        private readonly CrmDbContext db;

        public OrderService(CrmDbContext _db)
        {
            db = _db;
        }


        public OptionOrderProduct AddProductToOrder(OptionOrderProduct optionOrderProduct)
        {
            OrderProduct orderProduct = optionOrderProduct.GetOrderProduct();
            db.OrderProducts.Add(orderProduct);
            return new OptionOrderProduct(orderProduct);

        }

        public OptionOrder CreateOrder(OptionOrder orderOption)
        {
            //to do
            throw new NotImplementedException();
        }

        public List<OptionOrderProduct> GetOrderItems(int orderId)
        {
            //to do
            throw new NotImplementedException();
        }
    }
}
