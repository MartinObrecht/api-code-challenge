using codeChallenge.Application.Handlers.V1.Partners.Create;
using Microsoft.Extensions.DependencyInjection;

namespace codeChallenge.Core.Extensions
{
    public static class MediatRExtension
    {
        public static void AddMediatRApi(this IServiceCollection services)
        {
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblyContaining(typeof(CreatePartnerRequest)));
        }
    }
}