using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shipping.DAL.Entities;

public class MerchantBranchConfig : IEntityTypeConfiguration<MerchantBranch>
{
    public void Configure(EntityTypeBuilder<MerchantBranch> builder)
    {
        // Composite Key
        builder.HasKey(mb => new { mb.BranchID, mb.MerchantID });

        // Relationships
        builder.HasOne(mb => mb.Branch)
               .WithMany(b => b.MerchantBranches)
               .HasForeignKey(mb => mb.BranchID)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(mb => mb.Merchant)
               .WithMany(m => m.MerchantBranches)
               .HasForeignKey(mb => mb.MerchantID)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
