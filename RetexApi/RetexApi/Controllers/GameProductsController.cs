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
                // MASTER SYSTEM Consoles
                _context.GameProducts.Add(new GameProduct() { Name = "Master System", Price = 169.99, Condition = "USED-GREAT", Type = "Console", Console = "Master System", Year = 1986, ImageLocation = "assets/img/master_system.jpg" });
                _context.GameProducts.Add(new GameProduct() { Name = "Master System", Price = 99.99, Condition = "USED-GOOD", Type = "Console", Console = "Master System", Year = 1986, ImageLocation = "assets/img/master_system.jpg" });
                _context.GameProducts.Add(new GameProduct() { Name = "Master System", Price = 279.99, Condition = "USED-EXCELLENT", Type = "Console", Console = "Master System", Year = 1986, ImageLocation = "assets/img/master_system.jpg" });
                _context.GameProducts.Add(new GameProduct() { Name = "Master System", Price = 79.99, Condition = "USED-GOOD", Type = "Console", Console = "Master System", Year = 1986, ImageLocation = "assets/img/master_system.jpg" });

                // NES Consoles
                _context.GameProducts.Add(new GameProduct() { Name = "NES", Price = 19.99, Condition = "USED-PARTS", Type = "Console", Console = "NES", Year = 1985, ImageLocation = "assets/img/nes_console.jpg" });
                _context.GameProducts.Add(new GameProduct() { Name = "NES", Price = 64.99, Condition = "USED-GOOD", Type = "Console", Console = "NES", Year = 1985, ImageLocation = "assets/img/nes_console.jpg" });
                _context.GameProducts.Add(new GameProduct() { Name = "NES", Price = 44.99, Condition = "USED-GOOD", Type = "Console", Console = "NES", Year = 1985, ImageLocation = "assets/img/nes_console.jpg" });
                _context.GameProducts.Add(new GameProduct() { Name = "NES", Price = 229.99, Condition = "USED-EXCELLENT", Type = "Console", Console = "NES", Year = 1985, ImageLocation = "assets/img/nes_console.jpg" });

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

                // MASTER SYSTEM Games
                _context.GameProducts.Add(new GameProduct() { Name = "Prince of Persia", Price = 34.99, Condition = "USED-GREAT", Type = "Game", Console = "Master System", Year = 1992, ImageLocation = "assets/img/prince_of_persia.jpg" });
                _context.GameProducts.Add(new GameProduct() { Name = "R-Type", Price = 99.99, Condition = "USED-GREAT", Type = "Game", Console = "Master System", Year = 1987, ImageLocation = "assets/img/r-type.jpg" });
                _context.GameProducts.Add(new GameProduct() { Name = "California Games", Price = 15.99, Condition = "USED-GOOD", Type = "Game", Console = "Master System", Year = 1987, ImageLocation = "assets/img/california_games.jpg" });
                _context.GameProducts.Add(new GameProduct() { Name = "Alex Kid in Miracle World", Price = 44.99, Condition = "USED-GREAT", Type = "Game", Console = "Master System", Year = 1987, ImageLocation = "assets/img/alex_kidd.jpg" });

                // NES Games
                _context.GameProducts.Add(new GameProduct() { Name = "Super Mario Bros 3", Price = 19.99, Condition = "USED-GOOD", Type = "Game", Console = "NES", Year = 1990, ImageLocation = "assets/img/super_mario_bros_3.jpg" });
                _context.GameProducts.Add(new GameProduct() { Name = "Mega Man", Price = 79.99, Condition = "USED-EXCELLENT", Type = "Game", Console = "NES", Year = 1987, ImageLocation = "assets/img/mega_man.jpg" });
                _context.GameProducts.Add(new GameProduct() { Name = "Castlevania", Price = 39.99, Condition = "USED-GREAT", Type = "Game", Console = "NES", Year = 1987, ImageLocation = "assets/img/castlevania.jpg" });
                _context.GameProducts.Add(new GameProduct() { Name = "DuckTakes", Price = 19.99, Condition = "USED-GOOD", Type = "Game", Console = "NES", Year = 1989, ImageLocation = "assets/img/ducktales.jpg" });

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
