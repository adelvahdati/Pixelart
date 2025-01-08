using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pixelart.Orders.Infrastructure.Data;

namespace Pixelart.Orders.Infrastructure.Configuartions;

public class CustomerEntityConfiguration : IEntityTypeConfiguration<CustomerEntity>
{
    public void Configure(EntityTypeBuilder<CustomerEntity> builder)
    {
        builder.Property(customer=> customer.Family).HasMaxLength(100);
        builder.ToTable("Pixelart_Customers");
    }
}
