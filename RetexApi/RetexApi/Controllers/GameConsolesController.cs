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
    public class GameConsolesController : ControllerBase
    {
        private readonly GameConsoleContext _context;

        public GameConsolesController(GameConsoleContext context)
        {
            _context = context;
        }

        // GET: api/GameConsoles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameConsole>>> GetGameConsoles()
        {
            if (_context.GameConsoles.Count<GameConsole>() < 1)
            {
                // SNES
                _context.GameConsoles.Add(new GameConsole() { Name = "Super Nintendo", Price = 179.99, Condition = "USED-GREAT", ImageLocation = "assets/img/snes_console.jpg" });
                _context.GameConsoles.Add(new GameConsole() { Name = "Super Nintendo", Price = 699.99, Condition = "NEW-SEALED", ImageLocation = "assets/img/snes_console.jpg" });
                _context.GameConsoles.Add(new GameConsole() { Name = "Super Nintendo", Price = 219.99, Condition = "USED-EXCELLENT", ImageLocation = "assets/img/snes_console.jpg" });
                _context.GameConsoles.Add(new GameConsole() { Name = "Super Nintendo", Price = 19.99, Condition = "USED-PARTS", ImageLocation = "assets/img/snes_console.jpg" });
                // GENESIS
                _context.GameConsoles.Add(new GameConsole() { Name = "Sega Genesis", Price = 39.99, Condition = "USED-GREAT", ImageLocation = "assets/img/sega_genesis.jpg" });
                _context.GameConsoles.Add(new GameConsole() { Name = "Sega Genesis", Price = 9.99, Condition = "USED-PARTS", ImageLocation = "assets/img/sega_genesis.jpg" });
                _context.GameConsoles.Add(new GameConsole() { Name = "Sega Genesis", Price = 99.99, Condition = "USED-EXCELLENT", ImageLocation = "assets/img/sega_genesis.jpg" });
                _context.GameConsoles.Add(new GameConsole() { Name = "Sega Genesis", Price = 29.99, Condition = "USED-GOOD", ImageLocation = "assets/img/sega_genesis.jpg" });
                await _context.SaveChangesAsync();
            }

            return await _context.GameConsoles.ToListAsync();
        }

        // GET: api/GameConsoles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GameConsole>> GetGameConsole(int id)
        {
            var gameConsole = await _context.GameConsoles.FindAsync(id);

            if (gameConsole == null)
            {
                return NotFound();
            }

            return gameConsole;
        }

        // PUT: api/GameConsoles/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGameConsole(int id, GameConsole gameConsole)
        {
            if (id != gameConsole.Id)
            {
                return BadRequest();
            }

            _context.Entry(gameConsole).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameConsoleExists(id))
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

        // POST: api/GameConsoles
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<GameConsole>> PostGameConsole(GameConsole gameConsole)
        {
            _context.GameConsoles.Add(gameConsole);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetGameConsole", new { id = gameConsole.Id }, gameConsole);
            return CreatedAtAction(nameof(GetGameConsole), new { id = gameConsole.Id }, gameConsole);
        }

        // DELETE: api/GameConsoles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GameConsole>> DeleteGameConsole(int id)
        {
            var gameConsole = await _context.GameConsoles.FindAsync(id);
            if (gameConsole == null)
            {
                return NotFound();
            }

            _context.GameConsoles.Remove(gameConsole);
            await _context.SaveChangesAsync();

            return gameConsole;
        }

        private bool GameConsoleExists(int id)
        {
            return _context.GameConsoles.Any(e => e.Id == id);
        }
    }
}
