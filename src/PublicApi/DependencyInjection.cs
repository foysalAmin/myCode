using Microsoft.AspNetCore.Mvc.Infrastructure;
using PublicApi.Common.Errors;
using PublicApi.Common.Mapping;

namespace PublicApi;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory, PublicApiProblemDetailsFactory>();
        services.AddMappings();

        return services;
    }
}
