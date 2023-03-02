using codeChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace codeChallenge.Data.Configurations
{
    public class PartnerConfiguration : IEntityTypeConfiguration<Partner>
    {
        public void Configure(EntityTypeBuilder<Partner> builder)
        {
            builder.ToTable("Partner");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.TradingName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.OwnerName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Document).IsRequired().HasMaxLength(16);

            builder.HasOne(x => x.Addres).WithOne(x => x.Partner).HasForeignKey<Address>(p => p.PartnerId);
            builder.HasMany(x => x.CoverageArea).WithOne(x => x.Partner);
        
        }
    }
}