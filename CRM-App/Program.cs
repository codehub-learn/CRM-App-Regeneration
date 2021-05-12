using CRM_App.Model;
using System;

namespace CRM_App
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new()
            {
                FirstName = "Christos",
                LastName = "Christou",
                Address = "Athens"
            };
            Console.WriteLine(customer.ToString());
            Console.WriteLine(customer.CustomerId);
            Console.WriteLine(customer.FirstName);
            Console.WriteLine(customer.LastName);
            Console.WriteLine(customer.Email);

        }
    }
}
