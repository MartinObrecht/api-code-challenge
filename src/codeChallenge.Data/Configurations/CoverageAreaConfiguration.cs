
using codeChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace codeChallenge.Data.Configurations
{
    public class CoverageAreaConfiguration : IEntityTypeConfiguration<CoverageArea>
    {
        public void Configure(EntityTypeBuilder<CoverageArea> builder)
        {
            builder.ToTable("CoverageArea");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Type).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Coordinates).IsRequired().HasMaxLength(50000);
        }
    }
}