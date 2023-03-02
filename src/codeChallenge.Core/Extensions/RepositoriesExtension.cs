using codeChallenge.Data.Repositories;
using codeChallenge.Domain.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace codeChallenge.Core.Extensions
{
    public static class RepositoriesExtension
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICoverageAreaRepository, CoverageAreaRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IPartnerRepository, PartnerRepository>();
        }
    }
}