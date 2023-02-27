using codeChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace codeChallenge.Data
{
    public class codeChallengeContext : DbContext
    {
        public codeChallengeContext()
        {
        }

        public codeChallengeContext(DbContextOptions<codeChallengeContext> options) : base(options) { }

        public DbSet<Address> Address { get; set; }
        public DbSet<CoverageArea> CoverageArea { get; set; }
        public DbSet<Partner> Partner { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}