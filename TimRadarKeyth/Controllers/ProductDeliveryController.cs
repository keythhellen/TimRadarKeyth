using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimRadarKeyth.Models;

namespace TimRadarKeyth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDeliveryController : ControllerBase
    {
        private readonly TimRadarContext _context;

        public ProductDeliveryController(TimRadarContext context)
        {
            _context = context;
        }

        // GET: api/ProductDelivery
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDelivery>>> GetProductDeliveries()
        {
            return await _context.ProductDeliveries.ToListAsync();
        }

        // GET: api/ProductDelivery/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDelivery>> GetProductDelivery(int id)
        {
            var productDelivery = await _context.ProductDeliveries.FindAsync(id);

            if (productDelivery == null)
            {
                return NotFound();
            }

            return productDelivery;
        }

        // PUT: api/ProductDelivery/{id}
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductDelivery(int id, ProductDelivery productDelivery)
        {
            if (id != productDelivery.Id)
            {
                return BadRequest();
            }

            _context.Entry(productDelivery).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductDeliveryExists(id))
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

        // POST: api/ProductDelivery
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProductDelivery>> PostProductDelivery(ProductDelivery productDelivery)
        {
            _context.ProductDeliveries.Add(productDelivery);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductDelivery", new { id = productDelivery.Id }, productDelivery);
        }

        // DELETE: api/ProductDelivery/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductDelivery>> DeleteProductDelivery(int id)
        {
            var productDelivery = await _context.ProductDeliveries.FindAsync(id);
            if (productDelivery == null)
            {
                return NotFound();
            }

            _context.ProductDeliveries.Remove(productDelivery);
            await _context.SaveChangesAsync();

            return productDelivery;
        }

        private bool ProductDeliveryExists(int id)
        {
            return _context.ProductDeliveries.Any(e => e.Id == id);
        }
    }
}
