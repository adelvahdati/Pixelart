using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pixelart.Orders.Infrastructure.Data;

namespace Pixelart.Orders.Infrastructure.Configuartions;

public class OrderItemEntityConfiguration : IEntityTypeConfiguration<OrderItemEntity>
{
    public void Configure(EntityTypeBuilder<OrderItemEntity> builder)
    {
        // builder.HasOne(orderItem => orderItem.Order)
        //         .WithMany(order=> order.Items)
        //         .HasForeignKey(orderItem=> orderItem.OrderId);
    }
}
