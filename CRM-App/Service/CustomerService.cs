using CRM_App.Database;
using CRM_App.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_App.Service
{
    public class CustomerService
    {
        private CrmDbContext db;
        
        public CustomerService(CrmDbContext _db)
        {
            db = _db;
        }
        
        public Customer CreateCustomer(Customer customer)
        {


            //validation of the customer first
            if (customer == null)
            {
                return null;
            }

            if (customer.Email == null)
            {
                return null;
            }

            db.Customers.Add(customer);
            db.SaveChanges();
            return customer;

        }


        public List<Customer> ReadCustomers()
        {
            
            return db.Customers.ToList();
        }


        public Customer UpdateCustomer(int customerId, Customer customer)
        {
             
            Customer dbCustomer = db.Customers.Find(customerId);
            if (dbCustomer == null) return null;
            dbCustomer.Address = customer.Address;
            dbCustomer.Email = customer.Email;
            db.SaveChanges();

            return dbCustomer;

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
