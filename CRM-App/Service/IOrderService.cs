using CRM_App.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_App.Service
{
    public interface IOrderService
    {

        public OptionOrder CreateOrder(OptionOrder orderOption);

        public OptionOrderProduct AddProductToOrder(OptionOrderProduct optionOrderProduct);

        public List<OptionOrderProduct> GetOrderItems(int orderId);

    }
}
