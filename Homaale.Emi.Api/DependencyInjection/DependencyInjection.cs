using System.Collections.Immutable;
using Homaale.Emi.Api.Emi;

namespace Homaale.Emi.Api.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddHomaaleServices(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddCors(options => options.AddPolicy(Common.CorsPolicyName, builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
        return services;
    }
}
