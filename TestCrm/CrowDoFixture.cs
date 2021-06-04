using Autofac;
using CRM_App.Database;
using CRM_App.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCrm
{
    public sealed class CrowDoFixture : IDisposable
    {
        public CrmDbContext Context { get; private set; }
        public ICustomerService CustServ { get; private set; }

      

        public CrowDoFixture( )
        {



            var builder = new ContainerBuilder();
            var option = new DbContextOptionsBuilder<CrmDbContext>()
                .UseSqlServer(" ").Options;
            CrmDbContext context = new CrmDbContext(option);
            builder.RegisterInstance(context).As<UserContext>();

            builder.RegisterType<UserReponsitory>().AsSelf().As<IUserReponsitory>();

            builder.RegisterAssemblyTypes(typeof(DbFixture).GetTypeInfo().Assembly);

            Container = builder.Build();


            Context = new ();
            CustServ = new CustomerService(Context);
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
