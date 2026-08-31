using Orion.Application.Abstractions;
using Orion.Infrastructure.Auth;
using Orion.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Orion.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpContextAccessor();
        services.AddScoped<ICurrentUserAccessor, HttpCurrentUserAccessor>();

        var conn = configuration.GetConnectionString("Default");
        if (!string.IsNullOrWhiteSpace(conn))
        {
            services.AddDbContext<OrionDbContext>(o => o.UseNpgsql(conn));
        }

        return services;
    }
}
