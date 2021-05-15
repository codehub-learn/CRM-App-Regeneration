using CRM_App.Model;
using CRM_App.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_App.Service
{
    public interface ICustomerService
    { 
        public OptionCustomer CreateCustomer(OptionCustomer optionCustomer);
        public List<OptionCustomer> ReadCustomer();
        public OptionCustomer ReadCustomer(int customerId);
        public List<OptionCustomer> ReadCustomer(OptionCustomer optionCustomer);
        public OptionCustomer UpdateCustomer(int customerId,OptionCustomer optionCustomer );
        public bool DeleteCustomer(int customerId);
    }
}
