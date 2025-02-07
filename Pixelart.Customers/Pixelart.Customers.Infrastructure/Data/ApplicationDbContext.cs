using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pixelaret.Customers.Infrastructure.Configurations;
using Pixelart.Customers.Infrastructure.Data;

namespace Pixelaret.Customers.Infrastructure.Data;
public class ApplicationDbContext : DbContext{
    private readonly IConfiguration _configuration;

    public DbSet<CustomerEntity> Customers {get;set;}

    public ApplicationDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = _configuration.GetConnectionString("Pixelart-CustomersDb");
            optionsBuilder.UseSqlite(connectionString);
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        var customerConfiguration = new CustomerEntityConfiguration();
        customerConfiguration.Configure(modelBuilder.Entity<CustomerEntity>());
    }


}