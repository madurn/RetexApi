using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RetexApi.Models;

namespace RetexApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellItemsController : ControllerBase
    {
        private readonly SellItemContext _context;

        public SellItemsController(SellItemContext context)
        {
            _context = context;
        }

        // GET: api/SellItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SellItem>>> GetSellItems()
        {
            return await _context.SellItems.ToListAsync();
        }

        // GET: api/SellItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SellItem>> GetSellItem(int id)
        {
            var sellItem = await _context.SellItems.FindAsync(id);

            if (sellItem == null)
            {
                return NotFound();
            }

            return sellItem;
        }

        // PUT: api/SellItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSellItem(int id, SellItem sellItem)
        {
            if (id != sellItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(sellItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SellItemExists(id))
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

        // POST: api/SellItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SellItem>> PostSellItem(SellItem sellItem)
        {
            _context.SellItems.Add(sellItem);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetSellItem", new { id = sellItem.Id }, sellItem);
            return CreatedAtAction(nameof(GetSellItem), new { id = sellItem.Id }, sellItem);

        }

        // DELETE: api/SellItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SellItem>> DeleteSellItem(int id)
        {
            var sellItem = await _context.SellItems.FindAsync(id);
            if (sellItem == null)
            {
                return NotFound();
            }

            _context.SellItems.Remove(sellItem);
            await _context.SaveChangesAsync();

            return sellItem;
        }

        private bool SellItemExists(int id)
        {
            return _context.SellItems.Any(e => e.Id == id);
        }
    }
}
