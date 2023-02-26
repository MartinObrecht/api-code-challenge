using codeChallenge.Application.Handlers.V1.Partner.Create;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace codeChallenge.Core.Extensions
{
    public static class MediatRExtension
    {
        public static void AddMediatRApi(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreatePartnerHandler));
        }
    }
}