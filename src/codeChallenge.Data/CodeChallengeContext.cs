using codeChallenge.Data.Configurations;
using codeChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace codeChallenge.Data
{
    public class CodeChallengeContext : DbContext
    {
        public CodeChallengeContext()
        {
        }

        public CodeChallengeContext(DbContextOptions<CodeChallengeContext> options) : base(options) { }

        public DbSet<Address> Address { get; set; }
        public DbSet<CoverageArea> CoverageArea { get; set; }
        public DbSet<Partner> Partner { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new PartnerConfiguration().Configure(modelBuilder.Entity<Partner>());
            new AddressConfiguration().Configure(modelBuilder.Entity<Address>());
            new CoverageAreaConfiguration().Configure(modelBuilder.Entity<CoverageArea>());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer();
        }
    }
}