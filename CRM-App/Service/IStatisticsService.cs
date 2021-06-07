using CRM_App.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_App.Service
{
    public interface IStatisticsService
    {

        public Statistics GetStatistics(int customerId);

    }
}
