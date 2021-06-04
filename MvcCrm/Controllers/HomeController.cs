using CRM_App.Database;
using CRM_App.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MvcCrm.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCrm.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CrmDbContext _context;


        public HomeController(ILogger<HomeController> logger,CrmDbContext db)
        {
            _logger = logger;
            _context = db;
        }

        public IActionResult Index()
        {
            Customer customer = new Customer()
            {
                FirstName = "Dimitris",
            };
            _context.Customers.Add(customer);
            Order order2  =new() {  Date = DateTime.Now,
                Customer= customer
            };
            _context.Orders.Add(order2);
            _context.SaveChanges();

            //     Order order = _context.Orders.Find(1);

            Order order = _context.Orders.Include(p=>p.Customer)
                .Where(o => o.Date.Year == 2021).FirstOrDefault();

            Customer customerR = order.Customer;
            Console.WriteLine(customerR.FirstName);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
