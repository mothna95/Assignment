using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assignment.Data;
using Assignment.Models;

namespace Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly AssignmentDbContext _context;

        public InvoicesController(AssignmentDbContext context)
        {
            _context = context;
        }

        // GET: api/Invoices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Invoices>>> GetInvoice()
        {
            return await _context.Invoice.ToListAsync();
        }

        // GET: api/Invoices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Invoices>> GetInvoices(int id)
        {
            var invoices = await _context.Invoice.FindAsync(id);

            if (invoices == null)
            {
                return NotFound();
            }

            return invoices;
        }

        // PUT: api/Invoices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoices(int id, Invoices invoices)
        {
            if (id != invoices.InvoiceId)
            {
                return BadRequest();
            }

            _context.Entry(invoices).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoicesExists(id))
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

        // POST: api/Invoices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Invoices>> PostInvoices(Invoices invoices)
        {
            _context.Invoice.Add(invoices);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvoices", new { id = invoices.InvoiceId }, invoices);
        }

        // DELETE: api/Invoices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoices(int id)
        {
            var invoices = await _context.Invoice.FindAsync(id);
            if (invoices == null)
            {
                return NotFound();
            }

            _context.Invoice.Remove(invoices);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InvoicesExists(int id)
        {
            return _context.Invoice.Any(e => e.InvoiceId == id);
        }
    }
}
