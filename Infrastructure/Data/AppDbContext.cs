using Microsoft.EntityFrameworkCore;
using PortfolioManagement.Domain.Entities;

namespace PortfolioManagement.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options){}
        public DbSet<Asset> Assets => Set<Asset>();
        public DbSet<Portfolio> Portfolios => Set<Portfolio>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // configure the portofolio entity
            modelBuilder.Entity<Portfolio>(builder =>
            {
                builder.HasKey(p => p.Id);
                builder.Property(p => p.Name).HasMaxLength(100);
                builder.Property(p => p.UserId).IsRequired();
                builder.HasMany(p => p.Assets)
                       .WithOne()
                       .HasForeignKey("PortfolioId")
                       .OnDelete(DeleteBehavior.Cascade);
                builder.Metadata.FindNavigation(nameof(Portfolio.Assets))!.SetPropertyAccessMode(PropertyAccessMode.Field);
            });
            modelBuilder.Entity<Asset>(builder =>
            {
                builder.HasKey(a => a.Id);
                builder.Property(a => a.Quantity).HasPrecision(18, 8);
                builder.Property(a => a.CurrentPrice).HasPrecision(18, 4);
                builder.Property(a => a.TickerSymbol).IsRequired().HasMaxLength(10);
            });
        }

    }
}
