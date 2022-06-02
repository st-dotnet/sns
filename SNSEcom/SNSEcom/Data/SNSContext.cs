using Microsoft.EntityFrameworkCore;
using SNSEcom.Domain;

namespace SNSEcom.Data
{
    public class SNSContext:DbContext
    {
        public SNSContext(DbContextOptions<SNSContext> options) : base(options) { }
        public DbSet<Products> product { get; set; }
        public DbSet<Cart> cart { get; set; }
        public DbSet<CartItem> CartsItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(d => d.Cart)
                .WithMany(p=>p.Carts)
                .HasForeignKey(x => x.CartId);
            });
        }
    }
}
