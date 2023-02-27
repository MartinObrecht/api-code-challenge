using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using codeChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace codeChallenge.Data.Configurations
{
    public class PartnerConfiguration : IEntityTypeConfiguration<Partner>
    {
        public void Configure(EntityTypeBuilder<Partner> builder)
        {
            throw new NotImplementedException();
        }
    }
}