using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class MatrixIncDbContext : DbContext
    {
        public MatrixIncDbContext(DbContextOptions<MatrixIncDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Orders)
                .WithOne(o => o.Customer)
                .HasForeignKey(o => o.CustomerId).IsRequired();

			//modelBuilder.Entity<Order>()
			//    .HasOne(o => o.Customer)
			//    .WithMany(c => c.Orders)
			//    .OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<OrderProduct>()
	            .HasKey(op => new { op.OrderId, op.ProductId });

            modelBuilder.Entity<OrderProduct>()
                .Property(op => op.Quantity)
                .IsRequired();

			modelBuilder.Entity<OrderProduct>()
	            .HasOne(op => op.Order)
	            .WithMany(o => o.OrderProducts)
	            .HasForeignKey(op => op.OrderId);

			modelBuilder.Entity<OrderProduct>()
				.HasOne(op => op.Product)
				.WithMany(p => p.OrderProducts)
				.HasForeignKey(op => op.ProductId);

			modelBuilder.Entity<Product>()
                .HasMany(p => p.OrderProducts)
                .WithOne(o => o.Product);

            modelBuilder.Entity<Part>()
                .HasMany(p => p.Products)
                .WithMany(p => p.Parts);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Customer)
                .WithMany(c => c.Reviews)
                .HasForeignKey(r => r.CustomerId).IsRequired();

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Product)
                .WithMany(p => p.Reviews)
                .HasForeignKey(r => r.ProductId)
                .IsRequired();

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category);

            modelBuilder.Entity<Stock>()
                .HasOne(s => s.Product)
                .WithMany(p => p.Stocks);

            modelBuilder.Entity<Stock>()
                .HasOne(s => s.Location)
                .WithMany(l => l.Stocks);

            modelBuilder.Entity<Complaint>()
                .HasOne(c => c.Customer)
                .WithMany(c => c.Complaints)
                .HasForeignKey(c => c.CustomerId)
                .IsRequired();
            modelBuilder.Entity<Address>()
                .HasOne(a => a.Customer)
                .WithMany(c => c.Addresses)
                .HasForeignKey(a => a.CustomerId)
                .IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }

}
