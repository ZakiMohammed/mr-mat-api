using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mr_mat_api.Context;
using mr_mat_api.Models;

namespace mr_mat_api.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly MrMatContext _context;

        public CustomerController(MrMatContext context)
        {
            _context = context;
        }

        // GET: api/Customer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        // GET: api/Customer
        [HttpGet]
        [Route("pagination")]
        public async Task<ActionResult<IEnumerable<object>>> GetCustomers(int page, int size, string sort, string order)
        {
            var list = await _context.Customers.ToListAsync();
            var totalCount = list.Count();

            switch (sort)
            {
                case "id":
                    list = order == "asc" ? list.OrderBy(i => i.Id).ToList() : list.OrderByDescending(i => i.Id).ToList();
                    break;
                case "name":
                    list = order == "asc" ? list.OrderBy(i => i.Name).ToList() : list.OrderByDescending(i => i.Name).ToList();
                    break;
                case "mobile":
                    list = order == "asc" ? list.OrderBy(i => i.Mobile).ToList() : list.OrderByDescending(i => i.Mobile).ToList();
                    break;
                case "email":
                    list = order == "asc" ? list.OrderBy(i => i.Email).ToList() : list.OrderByDescending(i => i.Email).ToList();
                    break;
                default:
                    list = order == "asc" ? list.OrderBy(i => i.Id).ToList() : list.OrderByDescending(i => i.Id).ToList();
                    break;
            }            
            return new JsonResult(new {
                items = list.Skip((page - 1) * size).Take(size).ToList(),
                totalCount = totalCount
            });
        }

        // GET: api/Customer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(long id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // PUT: api/Customer/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(long id, Customer customer)
        {
            if (id != customer.Id)
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

        // POST: api/Customer
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
        }

        // DELETE: api/Customer/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> DeleteCustomer(long id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return customer;
        }

        private bool CustomerExists(long id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
    }
}
