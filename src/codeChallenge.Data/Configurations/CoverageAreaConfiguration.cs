
using codeChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace codeChallenge.Data.Configurations
{
    public class CoverageAreaConfiguration : IEntityTypeConfiguration<CoverageArea>
    {
        public void Configure(EntityTypeBuilder<CoverageArea> builder)
        {
            throw new NotImplementedException();
        }
    }
}