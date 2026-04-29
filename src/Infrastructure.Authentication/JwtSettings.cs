// Copyright (c) 2026 Team6. All rights reserved. 
//  No warranty, explicit or implicit, provided.

namespace Infrastructure.Authentication;

/// <summary>
/// Shared JWT configuration settings for API and Blazor clients.
/// </summary>
public class JwtSettings
{
    /// <summary>
    /// The expected issuer of the JWT.
    /// </summary>
    public string Issuer { get; set; } = string.Empty;

    /// <summary>
    /// The expected audience for the JWT.
    /// </summary>
    public string Audience { get; set; } = string.Empty;

    /// <summary>
    /// The signing key used to validate the JWT signature.
    /// </summary>
    public string IssuerSigningKey { get; set; } = string.Empty;
}
