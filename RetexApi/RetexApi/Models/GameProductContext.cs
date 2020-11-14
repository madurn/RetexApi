using Microsoft.EntityFrameworkCore;

namespace RetexApi.Models
{
    public class GameProductContext : DbContext
    {
        public GameProductContext(DbContextOptions<GameProductContext> options)
            : base(options)
        {
        }

        public DbSet<GameProduct> GameProducts { get; set; }
    }
}