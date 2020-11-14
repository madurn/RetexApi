using Microsoft.EntityFrameworkCore;

namespace RetexApi.Models
{
    public class CartItemContext : DbContext
    {
        public CartItemContext(DbContextOptions<CartItemContext> options)
            : base(options)
        {
        }

        public DbSet<CartItem> CartItems { get; set; }
    }
}
