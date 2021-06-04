using CRM_App.Database;
using CRM_App.Model;
using CRM_App.Option;
using CRM_App.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestCrm
{
   
    public class CustSrvTest:IClassFixture<CrowDoFixture> 
    {
        private readonly CrmDbContext context_;
        private readonly ICustomerService user_;

        public CustSrvTest(CrowDoFixture fixture)
        {
            context_ = fixture.Context;
            user_ = fixture.CustServ;
        }

        [Fact]
        public OptionCustomer CreateUserSuccess()
        {
            var options = new OptionCustomer()
            {
                Email = "dimitra@hotmail.gr",
                FirstName = "dimitra",
                LastName = "bourazani",
                Address = "Athens"
            };
            var user = user_.CreateCustomer(options);
            Assert.NotNull(user);
            Assert.Equal(options.Email, user.Email);
            Assert.Equal(options.FirstName, user.FirstName);
            Assert.Equal(options.LastName, user.LastName);
            Assert.Equal(options.Address, user.Address);

            var options1 = new OptionCustomer()
            {
                Email = options.Email,
                FirstName = options.FirstName,
                LastName = options.LastName,
                Address = options.Address
            };

            var query = user_.ReadCustomer(options1)
                .Where(u => u.CustomerId == user.CustomerId)
                .SingleOrDefault();
            Assert.NotNull(query);
            Assert.Equal(user.CustomerId, query.CustomerId);
            return user;
        }

        [Fact]
        public void CreateCustomerFailEmail()
        {
            var options = new OptionCustomer()
            {
                FirstName = "dimitra",
                LastName = "bourazani"
            };

            var user = user_.CreateCustomer(options);

            Assert.Null(user);

            options = new OptionCustomer()
            {
                Email = " ",
                FirstName = "dimitra",
                LastName = "bourazani"
            };

            user = user_.CreateCustomer(options);
            Assert.Null(user);

            options = new OptionCustomer()
            {
                Email = null,
                FirstName = "dimitra",
                LastName = "bourazani"
            };

            user = user_.CreateCustomer(options);
            Assert.Null(user);
        }
    }
}