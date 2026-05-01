// Copyright (c) 2026 Team6. All rights reserved. 
//  No warranty, explicit or implicit, provided.

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Core.Interfaces.Services;

using Domain.Entities;

using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Core.Services;

public class TokenService(IConfiguration configuration) : ITokenService
{
    private readonly IConfiguration _config = configuration;

    public string GenerateToken(User user, IList<string> roles)
    {
        List<Claim> claims =
        [
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new (ClaimTypes.Name, user.UserName!),
            new (ClaimTypes.Email, user.Email!),
            new (JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            .. roles.Select(role => new Claim(ClaimTypes.Role, role)),
        ];

        SymmetricSecurityKey signingKey = new(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
        SigningCredentials credentials = new(signingKey, SecurityAlgorithms.HmacSha256);
        int minutes = int.Parse(_config["Jwt:ExpirationMinutes"] ?? "60");

        JwtSecurityToken token = new(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(minutes),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
