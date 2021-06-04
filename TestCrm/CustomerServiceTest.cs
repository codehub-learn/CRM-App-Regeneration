 
using CRM_App.Database;
using CRM_App.Model;
using CRM_App.Option;
using CRM_App.Service;
using Microsoft.EntityFrameworkCore;
using Xunit;
 
namespace TestCrm
{
    public class CustomerServiceTest
    {
        [Fact] 
        public void CreateCustomerTest() 
        {
            OptionCustomer optionCustomer = new()
            {
                FirstName = "Dimitris",
                LastName = "Dimitriou",
                Email = "444"
            };



            var options = new Microsoft.EntityFrameworkCore
                        .DbContextOptionsBuilder<CrmDbContext>()
                      .UseInMemoryDatabase(databaseName: "CustomerListDatabase")
                      .Options;

            // Insert seed data into the database using one instance of the context
            using  var context = new CrmDbContext(options)  ;
             
                context.Customers.Add(new Customer {   FirstName = "Name 1", Email = "Action1" });
                context.Customers.Add(new Customer {   FirstName = "Name 2", Email = "Action2" });
                context.SaveChanges();
             

               

         

            CustomerService customerService = new(context );
            optionCustomer = customerService.CreateCustomer(optionCustomer);
            Assert.True(optionCustomer.CustomerId > 0, 
                "The optionCustomer has  been saved");



        }




    }
}
