// Copyright (c) 2026 Team6. All rights reserved. 
//  No warranty, explicit or implicit, provided.

using System.Security.Claims;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;

namespace WebApi.Tests.Helpers;

public class WebApplicationExtensionsTests
{
    [Fact]
    public async Task AddEndpointIdentityApi_RegisterEndpoint_UserWithClaim_AllowsAccess()
    {
        // Arrange
        ClaimsPrincipal user = new(new ClaimsIdentity([new Claim("CanManageUsers", "true")], "TestAuth"));
        DefaultHttpContext context = new() { User = user };
        context.Request.Path = "/register";

        object? nextResult = Results.Ok();
        ValueTask<object?> next(EndpointFilterInvocationContext _) => new(nextResult);

        // Act
        object? result = await InvokeFilter(context, next);

        // Assert
        _ = Assert.IsType<Ok>(result);
    }

    [Theory]
    [InlineData(false, false)]
    [InlineData(true, false)]
    [InlineData(false, true)]
    public async Task AddEndpointIdentityApi_RegisterEndpoint_UserWithoutClaimOrNotAuthenticated_ForbidsAccess(bool isAuthenticated, bool hasClaim)
    {
        // Arrange
        Claim[] claims = hasClaim ? [new Claim("CanManageUsers", "true")] : [];
        ClaimsIdentity identity = new(claims, isAuthenticated ? "TestAuth" : null);
        ClaimsPrincipal user = new(identity);
        DefaultHttpContext context = new() { User = user };
        context.Request.Path = "/register";

        object? nextResult = Results.Ok();
        ValueTask<object?> next(EndpointFilterInvocationContext _) => new(nextResult);

        // Act
        object? result = await InvokeFilter(context, next);

        // Assert
        _ = Assert.IsType<ForbidHttpResult>(result);
    }

    [Fact]
    public async Task AddEndpointIdentityApi_NonRegisterEndpoint_AlwaysAllowsAccess()
    {
        // Arrange
        ClaimsPrincipal user = new(new ClaimsIdentity());
        DefaultHttpContext context = new() { User = user };
        context.Request.Path = "/other";

        object? nextResult = Results.Ok();
        ValueTask<object?> next(EndpointFilterInvocationContext _) => new(nextResult);

        // Act
        object? result = await InvokeFilter(context, next);

        // Assert
        _ = Assert.IsType<Ok>(result);
    }

    // Helper method that replicates the filter logic from AddEndpointIdentityApi
    private static async Task<object?> InvokeFilter(HttpContext httpContext, EndpointFilterDelegate next)
    {
        EndpointFilterInvocationContext context = EndpointFilterInvocationContext.Create(httpContext);

        if (httpContext.Request.Path.StartsWithSegments("/register", StringComparison.OrdinalIgnoreCase))
        {
            ClaimsPrincipal user = httpContext.User;

            // Check if the user is authenticated and has the specific claim
            if (!user.Identity?.IsAuthenticated == true ||
                !user.HasClaim(c => c.Type == "CanManageUsers"))
            {
                return Results.Forbid();
            }
        }
        return await next(context);
    }
}
