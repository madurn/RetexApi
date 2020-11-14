using Microsoft.EntityFrameworkCore;

namespace RetexApi.Models
{
    public class GameConsoleContext : DbContext
    {
        public GameConsoleContext(DbContextOptions<GameConsoleContext> options)
            : base(options)
        {
        }

        public DbSet<GameConsole> GameConsoles { get; set; }
    }
}
