using CRM_App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_App.Option
{
    public class OptionOrderProduct
    {
        public int OrderProductId{ get; set; }
        public int OrderId { get; set; }
        public  int ProductId { get; set; }

        public string ProductName { get; set; }
        public   int Quantity{ get; set; }

        public OptionOrderProduct() { }
        public OptionOrderProduct(OrderProduct orderProduct) { 
        // to do
        } 
        public OrderProduct GetOrderProduct()
        {
            //to do
            return null;
        }


    }
}
