using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRM_App.Database;
using CRM_App.Model;
using CRM_App.Service;
using CRM_App.Option;

namespace MvcCrm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Customers1Controller : ControllerBase
    {
        private readonly CrmDbContext _context;

        private readonly ICustomerService _custService;
        private readonly IStatisticsService _statService;


       



        public Customers1Controller(CrmDbContext context,
            ICustomerService custService,
            IStatisticsService statService)
        {
            _context = context;
            _custService = custService;
            _statService = statService;
        }

        // GET: api/Customers1/optionCustomer
        [HttpGet("optionCustomer")]
        public List<OptionCustomer> GetOptionCustomers()
        {
            return _custService.ReadCustomer();
        }


        // GET: api/Customers1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        // GET: api/Customers1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // PUT: api/Customers1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Customers1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer", new { id = customer.CustomerId }, customer);
        }

        // DELETE: api/Customers1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.CustomerId == id);
        }

        // GET: api/Customers1/Statistics/5
        [HttpGet("Statistics/{id}")]
        public async Task<ActionResult<Statistics>> GetStatistics(int id)
        {
            Customer customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return _statService.GetStatistics(id);
        }




        //Post: api/Customers1/Login
        [HttpPost("Login")]
        public ActionResult<Customer> Login(OptionCustomer customer)
        {
            if (customer == null) return NotFound();
            Customer retCust = _context.Customers
                .Where(cust => cust.Username.Equals(customer.Username) &&
                cust.Password.Equals(customer.Password))
                 .FirstOrDefault();

            if (retCust == null) return NotFound();

            //store to session
            HttpContext.Session.SetString("CurrentCustomer", retCust.CustomerId + "");
            return retCust;
        }

        //GET: api/Customers1/Recall
        [HttpGet("Recall")]
        public ActionResult<string> Recall()
        {
            if (HttpContext.Session.GetString("CurrentCustomer") == null) return NotFound();
            return HttpContext.Session.GetString("CurrentCustomer");
        }

    }
}
