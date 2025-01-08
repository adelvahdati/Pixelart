
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pixelart.Orders.Infrastructure.Configuartions;

namespace Pixelart.Orders.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    private readonly IConfiguration _configuration;
    public DbSet<OrderEntity> Orders {get;set;}
    public DbSet<OrderItemEntity> OrderItems {get;set;}
    public DbSet<CustomerEntity> Customers {get;set;}
    public DbSet<ProductEntity> Products {get;set;}
    public ApplicationDbContext(){

    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = _configuration.GetConnectionString("PixelartDb");
            // optionsBuilder.UseSqlite(connectionString, b => b.MigrationsAssembly("Pixelart.Orders.Infrastructure"));
            optionsBuilder.UseSqlite(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var orderConfigs = new OrderEntityConfiguration();
        orderConfigs.Configure(modelBuilder.Entity<OrderEntity>());

        var customerConfig = new CustomerEntityConfiguration();
        customerConfig.Configure(modelBuilder.Entity<CustomerEntity>());

    }
}