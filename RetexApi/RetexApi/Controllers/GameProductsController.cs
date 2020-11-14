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
    public class GameProductsController : ControllerBase
    {
        private readonly GameProductContext _context;

        public GameProductsController(GameProductContext context)
        {
            _context = context;
        }

        // GET: api/GameProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameProduct>>> GetGameProducts()
        {
            if (_context.GameProducts.Count<GameProduct>() < 1)
            {
                // SNES Consoles
                _context.GameProducts.Add(new GameProduct() { Name = "Super Nintendo", Price = 179.99, Condition = "USED-GREAT", Type = "Console", Console = "Super Nintendo", Year = 1991, ImageLocation = "assets/img/snes_console.jpg" });
                _context.GameProducts.Add(new GameProduct() { Name = "Super Nintendo", Price = 699.99, Condition = "NEW-SEALED", Type = "Console", Console = "Super Nintendo", Year = 1991, ImageLocation = "assets/img/snes_console.jpg" });
                _context.GameProducts.Add(new GameProduct() { Name = "Super Nintendo", Price = 219.99, Condition = "USED-EXCELLENT", Type = "Console", Console = "Super Nintendo", Year = 1991, ImageLocation = "assets/img/snes_console.jpg" });
                _context.GameProducts.Add(new GameProduct() { Name = "Super Nintendo", Price = 19.99, Condition = "USED-PARTS", Type = "Console", Console = "Super Nintendo", Year = 1991, ImageLocation = "assets/img/snes_console.jpg" });
                // GENESIS Consoles
                _context.GameProducts.Add(new GameProduct() { Name = "Sega Genesis", Price = 39.99, Condition = "USED-GREAT", Type = "Console", Console = "Sega Genesis", Year = 1989, ImageLocation = "assets/img/sega_genesis.jpg" });
                _context.GameProducts.Add(new GameProduct() { Name = "Sega Genesis", Price = 9.99, Condition = "USED-PARTS", Type = "Console", Console = "Sega Genesis", Year = 1989, ImageLocation = "assets/img/sega_genesis.jpg" });
                _context.GameProducts.Add(new GameProduct() { Name = "Sega Genesis", Price = 99.99, Condition = "USED-EXCELLENT", Type = "Console", Console = "Sega Genesis", Year = 1989, ImageLocation = "assets/img/sega_genesis.jpg" });
                _context.GameProducts.Add(new GameProduct() { Name = "Sega Genesis", Price = 29.99, Condition = "USED-GOOD", Type = "Console", Console = "Sega Genesis", Year = 1989, ImageLocation = "assets/img/sega_genesis.jpg" });
                // SNES Games
                _context.GameProducts.Add(new GameProduct() { Name = "Super Mario World", Price = 19.99, Condition = "USED-GOOD", Type = "Game", Console = "Super Nintendo", Year = 1991, ImageLocation = "assets/img/super_mario_world.png" });
                _context.GameProducts.Add(new GameProduct() { Name = "The Legend of Zelda: A Link to the Past", Price = 44.99, Condition = "USED-GREAT", Type = "Game", Console = "Super Nintendo", Year = 1992, ImageLocation = "assets/img/a_link_to_the_past.jpg" });
                _context.GameProducts.Add(new GameProduct() { Name = "Super Metroid", Price = 64.99, Condition = "USED-EXCELLENT", Type = "Game", Console = "Super Nintendo", Year = 1994, ImageLocation = "assets/img/super_metroid.jpg" });
                _context.GameProducts.Add(new GameProduct() { Name = "Chrono Trigger", Price = 799.99, Condition = "NEW-SEALED", Type = "Game", Console = "Super Nintendo", Year = 1995, ImageLocation = "assets/img/chrono_trigger.jpg" });
                // GENESIS Games
                _context.GameProducts.Add(new GameProduct() { Name = "Sonic the Hedgehog 2", Price = 19.99, Condition = "USED-GREAT", Type = "Game", Console = "Sega Genesis", Year = 1992, ImageLocation = "assets/img/sonic_2.png" });
                _context.GameProducts.Add(new GameProduct() { Name = "Phantasy Star IV", Price = 99.99, Condition = "USED-GREAT", Type = "Game", Console = "Sega Genesis", Year = 1995, ImageLocation = "assets/img/phantasy_star_iv.jpg" });
                _context.GameProducts.Add(new GameProduct() { Name = "Streets of Rage 2", Price = 64.99, Condition = "USED-EXCELLENT", Type = "Game", Console = "Sega Genesis", Year = 1994, ImageLocation = "assets/img/streets_of_rage_2.jpg" });
                _context.GameProducts.Add(new GameProduct() { Name = "Gunstar Heroes", Price = 449.99, Condition = "NEW-SEALED", Type = "Game", Console = "Sega Genesis", Year = 1995, ImageLocation = "assets/img/gunstar_heroes.jpg" });
                await _context.SaveChangesAsync();
            }
            return await _context.GameProducts.ToListAsync();
        }

        // GET: api/GameProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GameProduct>> GetGameProduct(int id)
        {
            var gameProduct = await _context.GameProducts.FindAsync(id);

            if (gameProduct == null)
            {
                return NotFound();
            }

            return gameProduct;
        }

        // PUT: api/GameProducts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGameProduct(int id, GameProduct gameProduct)
        {
            if (id != gameProduct.Id)
            {
                return BadRequest();
            }

            _context.Entry(gameProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameProductExists(id))
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

        // POST: api/GameProducts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<GameProduct>> PostGameProduct(GameProduct gameProduct)
        {
            _context.GameProducts.Add(gameProduct);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetGameProduct", new { id = gameProduct.Id }, gameProduct);
            return CreatedAtAction(nameof(GetGameProduct), new { id = gameProduct.Id }, gameProduct);
        }

        // DELETE: api/GameProducts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GameProduct>> DeleteGameProduct(int id)
        {
            var gameProduct = await _context.GameProducts.FindAsync(id);
            if (gameProduct == null)
            {
                return NotFound();
            }

            _context.GameProducts.Remove(gameProduct);
            await _context.SaveChangesAsync();

            return gameProduct;
        }

        private bool GameProductExists(int id)
        {
            return _context.GameProducts.Any(e => e.Id == id);
        }
    }
}
