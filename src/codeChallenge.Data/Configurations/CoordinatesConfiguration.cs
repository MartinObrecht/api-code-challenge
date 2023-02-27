using codeChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace codeChallenge.Data.Configurations
{
    public class CoordinatesConfiguration : IEntityTypeConfiguration<Coordinates>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Coordinates> builder)
        {
            builder.ToTable("Coordinates");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Longitude).IsRequired();
            builder.Property(x => x.Latitute).IsRequired();

            builder.HasOne(x => x.CoverageArea).WithMany(c => c.Coordinates).HasForeignKey(x => x.CoverageAreaId);

        }
    }
}