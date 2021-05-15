using CRM_App.Database;
using CRM_App.Model;
using CRM_App.Option;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_App.Service
{
    public class CustomerService:ICustomerService
    {
        private readonly CrmDbContext db;
        
        public CustomerService(CrmDbContext _db)
        {
            db = _db;
        }
        
  
        public OptionCustomer CreateCustomer(OptionCustomer optionCustomer)
        {
            //validation of the customer first
            if (optionCustomer == null)
            {
                return null;
            }
            if (optionCustomer.Email == null)
            {
                return null;
            }
            Customer customer = optionCustomer.GetCustomer();
            db.Customers.Add(customer);
            db.SaveChanges();
            return new OptionCustomer(customer);
        }

        public List<OptionCustomer> ReadCustomer()
        {
            List<Customer> customers = db.Customers.ToList();
            List<OptionCustomer> optionCustomers = new();
            customers.ForEach(customer => optionCustomers.Add(new OptionCustomer(customer)));
            return optionCustomers;
        }

        public OptionCustomer ReadCustomer(int customerId)
        {
           Customer customer =  db.Customers.Find(customerId);
            if (customer == null)
            {
                return null;
            }
            return new OptionCustomer(customer);
        }

        public List<OptionCustomer> ReadCustomer(OptionCustomer optionCustomer)
        {
            List<Customer> customers = db.Customers
                .Where(customer => customer.Address.Equals(optionCustomer.Address))
                .ToList();
            List<OptionCustomer> optionCustomers = new();
            customers.ForEach(customer => optionCustomers.Add(new OptionCustomer(customer)));
            return optionCustomers;
        }

        public OptionCustomer UpdateCustomer(int customerId, OptionCustomer optionCustomer)
        {
            Customer dbCustomer = db.Customers.Find(customerId);
            if (dbCustomer == null) return null;
            dbCustomer.Address = optionCustomer.Address;
            dbCustomer.Email = optionCustomer.Email;
            db.SaveChanges();

            return new OptionCustomer( dbCustomer);

        }

        public bool DeleteCustomer(int customerId)
        {
           Customer dbCustomer = db.Customers.Find(customerId);
            if (dbCustomer == null) return false;
            db.Customers.Remove(dbCustomer);
            return true;
        }


    }
}
