// Copyright (c) 2026 Team6. All rights reserved. 
//  No warranty, explicit or implicit, provided.

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Authentication;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        _ = DotNetEnv.Env.Load(AppContext.BaseDirectory);

        // JwtSettings
        JwtSettings jwtSettings = new()
        {
            Issuer = configuration["TokenValidationParameters__Issuer"] ?? string.Empty,
            Audience = configuration["TokenValidationParameters__Audience"] ?? string.Empty,
            IssuerSigningKey = configuration["TokenValidationParameters__IssuerSigningKey"] ?? string.Empty
        };
        _ = services.AddSingleton(jwtSettings);

        return services;
    }
}
