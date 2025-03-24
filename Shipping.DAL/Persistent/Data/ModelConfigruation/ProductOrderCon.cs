using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

internal class ProductOrderCon : IEntityTypeConfiguration<Order_Product>
{
    public void Configure(EntityTypeBuilder<Order_Product> builder)
    {
        // Define composite key
        builder.HasKey(op => new { op.ProductId, op.OrderId });

        // Define relationships
        builder.HasOne(op => op.Product)
               .WithMany(p => p.Order_Products)
               .HasForeignKey(op => op.ProductId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(op => op.Order)
               .WithMany(o => o.OrderProducts)
               .HasForeignKey(op => op.OrderId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
