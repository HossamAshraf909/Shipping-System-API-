using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shipping.DAL.Entities;

public class DeliveryBranchConfig : IEntityTypeConfiguration<DeliveryBranch>
{
    public void Configure(EntityTypeBuilder<DeliveryBranch> builder)
    {
        // Composite Key
        builder.HasKey(db => new { db.BranchID, db.DeliveryID });

        // Relationships
        builder.HasOne(db => db.Branch)
               .WithMany(b => b.DeliveryBranches)
               .HasForeignKey(db => db.BranchID)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(db => db.Delivery)
               .WithMany(d => d.DeliveryBranches)
               .HasForeignKey(db => db.DeliveryID)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
