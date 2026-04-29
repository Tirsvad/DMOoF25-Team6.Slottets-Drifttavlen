// Copyright (c) 2026 Team6. All rights reserved. 
//  No warranty, explicit or implicit, provided.

using System.Text;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Authentication.Extensions;

public static class JwtAuthenticationExtensions
{
    /// <summary>
    /// Adds JWT Bearer authentication using configuration values.
    /// </summary>
    /// <param name="services">The service collection to add authentication to.</param>
    /// <param name="configuration">The configuration containing JWT parameters.</param>
    /// <returns>The service collection for chaining.</returns>
    public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        _ = services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            string issuer = configuration["TokenValidationParameters:Issuer"] ?? throw new InvalidOperationException("TokenValidationParameters:Issuer not found in configuration.");
            string audience = configuration["TokenValidationParameters:Audience"] ?? throw new InvalidOperationException("TokenValidationParameters:Audience not found in configuration.");
            string key = configuration["TokenValidationParameters:IssuerSigningKey"] ?? throw new InvalidOperationException("TokenValidationParameters:IssuerSigningKey not found in configuration.");
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = issuer,
                ValidAudience = audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
            };
        });
        return services;
    }
}
