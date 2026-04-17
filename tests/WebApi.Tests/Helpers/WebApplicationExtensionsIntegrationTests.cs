// Copyright (c) 2026 Team6. All rights reserved.
//  No warranty, explicit or implicit, provided.

using System.Net;
using System.Text;

using Api;

using Microsoft.AspNetCore.Mvc.Testing;

namespace WebApi.Tests.Helpers;

public class WebApplicationExtensionsIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public WebApplicationExtensionsIntegrationTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory.WithWebHostBuilder(builder =>
        {
            _ = builder.ConfigureServices(services =>
            {
                // Optionally override services for test isolation
            });
            // Removed builder.Configure(app => app.AddEndpointIdentityApi());
            // The extension should be registered in Program.cs, not here.
        });
    }

    [Fact]
    public async Task RegisterEndpoint_WithClaim_AllowsAccess()
    {
        // Arrange
        HttpClient client = _factory.CreateClient();
        HttpRequestMessage request = new(HttpMethod.Post, "/register")
        {
            Content = new StringContent("{\"emailAddress\":\"test@example.com\",\"password\":\"Test1234\"}", Encoding.UTF8, "application/json")
        };
        // Simulate authenticated user with claim
        request.Headers.Add("Test-Auth", "CanManageUsers");

        // Act
        HttpResponseMessage response = await client.SendAsync(request, TestContext.Current.CancellationToken);

        // Assert
        Assert.NotEqual(HttpStatusCode.Forbidden, response.StatusCode);
    }

    [Fact]
    public async Task RegisterEndpoint_WithoutClaim_ForbidsAccess()
    {
        // Arrange
        HttpClient client = _factory.CreateClient();
        HttpRequestMessage request = new(HttpMethod.Post, "/register")
        {
            Content = new StringContent("{\"email\":\"test@example.com\",\"password\":\"Test1234\"}", Encoding.UTF8, "application/json")
        };
        // No claim header

        // Act
        HttpResponseMessage response = await client.SendAsync(request, TestContext.Current.CancellationToken);

        // Assert
        Assert.Equal(HttpStatusCode.Forbidden, response.StatusCode);
    }

    [Fact]
    public async Task NonRegisterEndpoint_AlwaysAllowsAccess()
    {
        // Arrange
        HttpClient client = _factory.CreateClient();
        HttpRequestMessage request = new(HttpMethod.Get, "/other");

        // Act
        HttpResponseMessage response = await client.SendAsync(request, TestContext.Current.CancellationToken);

        // Assert
        Assert.NotEqual(HttpStatusCode.Forbidden, response.StatusCode);
    }
}
