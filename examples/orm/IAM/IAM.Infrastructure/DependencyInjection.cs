using IAM.Application.Common;
using IAM.Infrastructure.Cache_Redis.VerifyCode;
using IAM.Infrastructure.Common;
using IAM.Infrastructure.Persistence_PgSql;
using IAM.Infrastructure.Persistence_PgSql.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace IAM.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddCommonServices();
        services.AddPersistence();
        services.AddRedis();

        return services;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql("Host=localhost;Database=iam;Username=postgres;Password=postgres"));

        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }

    private static IServiceCollection AddRedis(this IServiceCollection services)
    {
        var multiplexer = ConnectionMultiplexer.Connect("localhost:6380");
        var database = multiplexer.GetDatabase();

        services.AddSingleton(database);

        services.AddSingleton<IVerifyCodeCacheProvider, VerifyCodeCacheProvider>();

        return services;
    }

    private static IServiceCollection AddCommonServices(this IServiceCollection services)
    {
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IPasswordHasher, PasswordHasher>();
        services.AddSingleton<IVerifyCodeGenerator, VerifyCodeGenerator>();

        return services;
    }
}