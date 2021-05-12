using CRM_App.Database;
using CRM_App.Model;
using CRM_App.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace CRM_App
{
    class Program
    {
        static void Main(string[] args)
        {
            using CrmDbContext db = new CrmDbContext();
            CustomerService customerService = new(db);
            //Customer customer = new()
            //{
            //    FirstName = "Christos",
            //    LastName = "Christou",
            //    Address = "Athens"
            //};

            //Console.WriteLine($"customerId = {customer.CustomerId}"
            //    + $" FirstName = {customer.FirstName}");

            //
            //customer = customerService.CreateCustomer(customer);
            //if (customer != null)
            //{
            //    Console.WriteLine($"customerId = {customer.CustomerId}"
            //    + $" FirstName = {customer.FirstName}");

            //}
            //else
            //{
            //    Console.WriteLine("customer has not been created");

            //}

            //List<Customer> customers = customerService.ReadCustomers();

            //foreach(Customer customer in customers)
            //    {
            //    Console.WriteLine(customer);
            //}

            Customer customer = new()
            {
                Email = "ioannis@gmail",
                Address = "Serres"
            };

            Customer dbCustomer = customerService.UpdateCustomer(3, customer);

            Console.WriteLine(dbCustomer);

        }
    }
}
