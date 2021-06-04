using CRM_App.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_App.Database
{
    public class CrmDbContext:DbContext
    {
        public CrmDbContext(  DbContextOptions options) : base(options)
        {
        }
        public CrmDbContext() { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Supplier> Suppliers { get; set; } 

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=RegenerationCrm;Integrated Security=True");
        //}
    }
   

}
