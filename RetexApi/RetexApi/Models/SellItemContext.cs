using Microsoft.EntityFrameworkCore;

namespace RetexApi.Models
{
    public class SellItemContext : DbContext
    {
        public SellItemContext(DbContextOptions<SellItemContext> options)
            : base(options)
        {
        }

        public DbSet<SellItem> SellItems { get; set; }
    }
}