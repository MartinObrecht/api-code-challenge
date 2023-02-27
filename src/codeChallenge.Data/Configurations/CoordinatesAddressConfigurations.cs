using codeChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace codeChallenge.Data.Configurations
{
    public class CoordinatesAddressConfigurations : IEntityTypeConfiguration<CoordinatesAddress>
    {
        public void Configure(EntityTypeBuilder<CoordinatesAddress> builder)
        {
            builder.ToTable("CoordinatesAddress");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Longitude).IsRequired();
            builder.Property(x => x.Latitute).IsRequired();

            builder.HasOne(x => x.Address).WithMany(c => c.CoordinatesAddress).HasForeignKey(x => x.AddressId);

        }
    }
}