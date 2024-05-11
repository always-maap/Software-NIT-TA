using System.Reflection;
using System.Text;
using IAM.Application.Common;
using IAM.Infrastructure.Common;
using IAM.Presentation.Common;
using Mapster;
using MapsterMapper;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace IAM.Presentation;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwagger();
        services.AddHttpContextAccessor();
        services.AddAuth();
        services.AddAuthorization();
        services.AddCurrentUser();
        services.AddMapper();

        return services;
    }

    private static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header using the Bearer scheme. Example: Bearer 12345abcdef",
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
            });
        });

        return services;
    }

    private static IServiceCollection AddAuth(this IServiceCollection services)
    {
        var jwtSettings = new JwtSettings
        {
            Secret = "85y/7XbloWlrVQuIFLFRyOxH67sL5UPNjJoleFbXfz0=",
            Issuer = "http://localhost:5000",
            Audience = "http://localhost:5000",
            ExpiryMinutes = 60 * 24 * 30
        };
        services.AddAuthentication()
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey =
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
                };
            });

        return services;
    }

    private static IServiceCollection AddCurrentUser(this IServiceCollection services)
    {
        services.AddSingleton<ICurrentUser, CurrentUser>();

        return services;
    }

    private static IServiceCollection AddMapper(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());

        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();

        return services;
    }
}