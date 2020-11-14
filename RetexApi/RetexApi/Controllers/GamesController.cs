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
    public class GamesController : ControllerBase
    {
        private readonly GameContext _context;

        public GamesController(GameContext context)
        {
            _context = context;
        }

        // GET: api/Games
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Game>>> GetGames()
        {
            if (_context.Games.Count<Game>() < 1)
            {
                // SNES
                _context.Games.Add(new Game() { Name = "Super Mario World", Price = 19.99, Console = "Super Nintendo", Year = 1990, Condition = "USED-GOOD", ImageLocation = "assets/img/super_mario_world.png" });
                _context.Games.Add(new Game() { Name = "The Legend of Zelda: A Link to the Past", Price = 44.99, Console = "Super Nintendo", Year = 1992, Condition = "USED-GREAT", ImageLocation = "assets/img/a_link_to_the_past.jpg" });
                _context.Games.Add(new Game() { Name = "Super Metroid", Price = 64.99, Console = "Super Nintendo", Year = 1994, Condition = "USED-EXCELLENT", ImageLocation = "assets/img/super_metroid.jpg" });
                _context.Games.Add(new Game() { Name = "Chrono Trigger", Price = 799.99, Console = "Super Nintendo", Year = 1995, Condition = "NEW-SEALED", ImageLocation = "assets/img/chrono_trigger.jpg" });

                // GENESIS
                _context.Games.Add(new Game() { Name = "Sonic the Hedgehog 2", Price = 19.99, Console = "Sega Genesis", Year = 1992, Condition = "USED-GREAT", ImageLocation = "assets/img/sonic_2.png" });
                _context.Games.Add(new Game() { Name = "Phantasy Star IV", Price = 99.99, Console = "Sega Genesis", Year = 1995, Condition = "USED-GREAT", ImageLocation = "assets/img/phantasy_star_iv.jpg" });
                _context.Games.Add(new Game() { Name = "Streets of Rage 2", Price = 64.99, Console = "Sega Genesis", Year = 1994, Condition = "USED-EXCELLENT", ImageLocation = "assets/img/streets_of_rage_2.jpg" });
                _context.Games.Add(new Game() { Name = "Gunstar Heroes", Price = 449.99, Console = "Sega Genesis", Year = 1995, Condition = "NEW-SEALED", ImageLocation = "assets/img/gunstar_heroes.jpg" });
                await _context.SaveChangesAsync();
            }
            return await _context.Games.ToListAsync();
        }

        // GET: api/Games/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetGame(int id)
        {
            var game = await _context.Games.FindAsync(id);

            if (game == null)
            {
                return NotFound();
            }

            return game;
        }

        // PUT: api/Games/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGame(int id, Game game)
        {
            if (id != game.Id)
            {
                return BadRequest();
            }

            _context.Entry(game).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameExists(id))
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

        // POST: api/Games
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Game>> PostGame(Game game)
        {
            _context.Games.Add(game);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetGame", new { id = game.Id }, game);
            return CreatedAtAction(nameof(GetGame), new { id = game.Id }, game);
        }

        // DELETE: api/Games/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Game>> DeleteGame(int id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }

            _context.Games.Remove(game);
            await _context.SaveChangesAsync();

            return game;
        }

        private bool GameExists(int id)
        {
            return _context.Games.Any(e => e.Id == id);
        }
    }
}
