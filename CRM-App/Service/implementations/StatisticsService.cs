using CRM_App.Database;
using CRM_App.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_App.Service.implementations
{
    public class StatisticsService : IStatisticsService
    {
        private readonly CrmDbContext db;

        public StatisticsService(CrmDbContext _db)
        {
            db = _db;
        }

        public Statistics GetStatistics(int customerId)
        {
            return new()
            {
                UserId = customerId,
                CountProjects = db.Orders
                    .Where(order => order.Customer.CustomerId == customerId)
                    .Count(),
                TotalAmount = db.Orders
                    .Where(order => order.Customer.CustomerId == customerId)
                    .Select(order => order.TotalAmount)
                    .Sum(),
            };

        }
    }
}

 
