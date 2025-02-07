using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pixelart.Customers.Infrastructure.Data;

namespace Pixelaret.Customers.Infrastructure.Configurations;

public class CustomerEntityConfiguration : IEntityTypeConfiguration<CustomerEntity>
{
    public void Configure(EntityTypeBuilder<CustomerEntity> builder)
    {
        // If you need to chnage the table name or columns, you can config your entity hear
    }
}
