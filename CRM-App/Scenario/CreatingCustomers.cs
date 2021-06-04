using CRM_App.Database;
using CRM_App.Model;
using CRM_App.Option;
using CRM_App.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_App.Scenario
{
    public static class CreatingCustomers
    {
        //public  static void Creating()
        //{
        //    using CrmDbContext db = new CrmDbContext();
        //    CustomerService customerService = new(db);
        //    //Customer customer = new()
        //    //{
        //    //    FirstName = "Christos",
        //    //    LastName = "Christou",
        //    //    Address = "Athens"
        //    //};

        //    //Console.WriteLine($"customerId = {customer.CustomerId}"
        //    //    + $" FirstName = {customer.FirstName}");

        //    //
        //    //customer = customerService.CreateCustomer(customer);
        //    //if (customer != null)
        //    //{
        //    //    Console.WriteLine($"customerId = {customer.CustomerId}"
        //    //    + $" FirstName = {customer.FirstName}");

        //    //}
        //    //else
        //    //{
        //    //    Console.WriteLine("customer has not been created");

        //    //}

        //    //List<Customer> customers = customerService.ReadCustomers();

        //    //foreach(Customer customer in customers)
        //    //    {
        //    //    Console.WriteLine(customer);
        //    //}

        //    Customer customer = new()
        //    {
        //        Email = "ioannis@gmail",
        //        Address = "Serres"
        //    };

        //    Customer dbCustomer = customerService.UpdateCustomer(3, customer);

        //    Console.WriteLine(dbCustomer);
        //}


        //public static void InsertCustomer()
        //{
        //    OptionCustomer optionCustomer = new OptionCustomer()
        //    {
        //        FirstName = "Dimitris",
        //        Email = "dimitris@gmail.com",

        //    };

        //    using CrmDbContext db = new();
        //    ICustomerService customerService = new CustomerService(db);

        //    OptionCustomer optionCustomerResult = customerService.CreateCustomer(optionCustomer);

        //    Console.WriteLine(optionCustomerResult.CustomerId);
        //}
    }
}
