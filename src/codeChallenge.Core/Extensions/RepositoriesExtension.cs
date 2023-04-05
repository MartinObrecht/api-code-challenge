using codeChallenge.Data;
using codeChallenge.Data.Repositories;
using codeChallenge.Domain.Interfaces;
using codeChallenge.Domain.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace codeChallenge.Core.Extensions
{
    public static class RepositoriesExtension
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICodeChallengeContext, CodeChallengeContext>();
            services.AddScoped<IPartnerRepository, PartnerRepository>();
        }
    }
}