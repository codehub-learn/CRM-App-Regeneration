using CRM_App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_App.Option
{
    public class OptionCustomer
    {

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationDate { get; set; }


        public Customer GetCustomer()
        {
            Customer customer = new() {
                Address = Address,
                Email = Email,
                FirstName = FirstName,
                LastName = LastName,
                Password = Password,
                Username = Username,
                RegistrationDate = DateTime.Now
            };
            return customer;
        }

        public OptionCustomer() { }
        public OptionCustomer(Customer customer)
        {
            if (customer != null) 
            { 
                Address = customer.Address;
                Email = customer.Email;
                FirstName = customer.FirstName;
                LastName = customer.LastName;
                Password = customer.Password;
                Username = customer.Username;
                RegistrationDate = customer.RegistrationDate;
                CustomerId = customer.CustomerId; 
            }
           
        }

    }
}
