using Microsoft.EntityFrameworkCore;
using Shopping.Infrastructure.Models;

namespace Shopping.Infrastructure {
    public class ShoppingContext : DbContext {
        public ShoppingContext(DbContextOptions options) : base(options) {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Carrier> Carriers { get; set; }
        public DbSet<CarrierMethod> CarrierMethods { get; set; }
        public DbSet<ShippingMethod> ShippingMethods { get; set; }
        public DbSet<Permission> Permissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Categories)
                .WithMany(c => c.Products)
                .UsingEntity<Dictionary<string, object>>(
                "CategoryProduct",
                j => j.HasOne<Category>()
                    .WithMany()
                    .HasForeignKey("CategoriesId")
                    .OnDelete(DeleteBehavior.Cascade),
                j => j.HasOne<Product>()
                    .WithMany()
                    .HasForeignKey("ProductsId")
                    .OnDelete(DeleteBehavior.Cascade),
                j => {
                    j.ToTable("CategoryProduct");
                    j.HasKey("ProductsId", "CategoriesId");
                }
                );

        }

    }
}
