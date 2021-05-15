using CRM_App.Database;
using CRM_App.Model;
using CRM_App.Option;
using CRM_App.Scenario;
using CRM_App.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace CRM_App
{
    public static class Program
    {
        static void Main()
        {

            //   CreatingCustomers 

            OptionCustomer optionCustomer = new OptionCustomer()
            {
                Address = "Athens",
    

            };


            using CrmDbContext db = new();
            ICustomerService customerService = new CustomerService(db);

            List<OptionCustomer> customers = customerService.ReadCustomer(optionCustomer);

            customers.ForEach(customer =>
                Console.WriteLine($"{customer.CustomerId} {customer.FirstName}"));

           


        }
    }
}
