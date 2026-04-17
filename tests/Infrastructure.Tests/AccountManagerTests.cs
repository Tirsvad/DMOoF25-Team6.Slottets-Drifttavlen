// Copyright (c) 2026 Team6. All rights reserved. 
//  No warranty, explicit or implicit, provided.

using System.Net;
using System.Net.Http.Json;

using Core.DTOs.Account;

using Infrastructure.Managers;

using Moq;
using Moq.Protected;

namespace Infrastructure.Tests;

public class AccountManagerTests
{
    private static HttpClient CreateMockHttpClient(HttpResponseMessage response)
    {
        Mock<HttpMessageHandler> handlerMock = new(MockBehavior.Strict);
        handlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(response)
            .Verifiable();
        return new HttpClient(handlerMock.Object)
        {
            BaseAddress = new System.Uri("http://localhost")
        };
    }

    [Fact]
    public async Task CreateAccountAsync_ValidResponse_ReturnsSuccess()
    {
        RegistrationResponseDto expected = new() { IsSuccessful = true };
        HttpResponseMessage response = new(HttpStatusCode.OK)
        {
            Content = JsonContent.Create(expected)
        };
        HttpClient httpClient = CreateMockHttpClient(response);
        AccountManager manager = new(httpClient);

        // Act
        RegistrationResponseDto result = await manager.Register(new RegistrationRequestDto
        {
            EmailAddress = "test@example.com",
            Password = "Password123!",
            ConfirmPassword = "Password123!"
        });

        // Assert
        Assert.True(result.IsSuccessful);
    }

    [Fact]
    public async Task CreateAccountAsync_InvalidJson_ReturnsFailedResponse()
    {
        // Arrange
        HttpResponseMessage response = new(HttpStatusCode.OK)
        {
            Content = new StringContent("not json")
        };
        HttpClient httpClient = CreateMockHttpClient(response);
        AccountManager manager = new(httpClient);

        // Act
        RegistrationResponseDto result = await manager.Register(new RegistrationRequestDto
        {
            EmailAddress = "test@example.com",
            Password = "Password123!",
            ConfirmPassword = "Password123!"
        });

        // Assert
        Assert.False(result.IsSuccessful);
        Assert.Contains("Failed to parse registration response.", result.ErrorMessages!);
    }

    [Fact]
    public async Task LoginAsync_ValidResponse_ReturnsJwtToken()
    {
        // Arrange
        LoginResponseDto expected = new() { JwtToken = "token", RefreshToken = "refresh" };
        HttpResponseMessage response = new(HttpStatusCode.OK)
        {
            Content = JsonContent.Create(expected)
        };
        HttpClient httpClient = CreateMockHttpClient(response);
        AccountManager manager = new(httpClient);

        // Act
        LoginResponseDto result = await manager.LoginAsync(new LoginRequestDto
        {
            EmailAddress = "test@example.com",
            Password = "Password123!"
        });

        // Assert
        Assert.Equal("token", result.JwtToken);
        Assert.Equal("refresh", result.RefreshToken);
    }

    [Fact]
    public async Task LoginAsync_InvalidJson_ReturnsFailedResponse()
    {
        // Arrange
        HttpResponseMessage response = new(HttpStatusCode.OK)
        {
            Content = new StringContent("not json")
        };
        HttpClient httpClient = CreateMockHttpClient(response);
        AccountManager manager = new(httpClient);

        // Act
        LoginResponseDto result = await manager.LoginAsync(new LoginRequestDto
        {
            EmailAddress = "test@example.com",
            Password = "Password123!"
        });

        // Assert
        Assert.Null(result.JwtToken);
        Assert.Null(result.RefreshToken);
        Assert.Contains("Failed to parse login response.", result.ErrorMessages!);
    }

    [Fact]
    public async Task LogoutAsync_ValidResponse_ReturnsSuccess()
    {
        // Arrange
        LogoutResponseDto expected = new() { IsSuccessful = true };
        HttpResponseMessage response = new(HttpStatusCode.OK)
        {
            Content = JsonContent.Create(expected)
        };
        HttpClient httpClient = CreateMockHttpClient(response);
        AccountManager manager = new(httpClient);

        // Act
        LogoutResponseDto result = await manager.LogoutAsync(new LogoutRequestDto { JwtToken = "test-token" });

        // Assert
        Assert.True(result.IsSuccessful);
    }

    [Fact]
    public async Task LogoutAsync_InvalidJson_ReturnsFailedResponse()
    {
        // Arrange
        HttpResponseMessage response = new(HttpStatusCode.OK)
        {
            Content = new StringContent("not json")
        };
        HttpClient httpClient = CreateMockHttpClient(response);
        AccountManager manager = new(httpClient);

        // Act
        LogoutResponseDto result = await manager.LogoutAsync(new LogoutRequestDto { JwtToken = "test-token" });

        // Assert
        Assert.False(result.IsSuccessful);
        Assert.Contains("Failed to parse logout response.", result.ErrorMessages!);
    }

    [Fact]
    public async Task RefreshTokenAsync_ValidResponse_ReturnsJwtToken()
    {
        // Arrange
        RefreshTokenResponseDto expected = new() { JwtToken = "token", RefreshToken = "refresh" };
        HttpResponseMessage response = new(HttpStatusCode.OK)
        {
            Content = JsonContent.Create(expected)
        };
        HttpClient httpClient = CreateMockHttpClient(response);
        AccountManager manager = new(httpClient);

        // Act
        RefreshTokenResponseDto result = await manager.RefreshTokenAsync(new RefreshTokenRequestDto());

        // Assert
        Assert.Equal("token", result.JwtToken);
        Assert.Equal("refresh", result.RefreshToken);
    }

    [Fact]
    public async Task RefreshTokenAsync_InvalidJson_ReturnsFailedResponse()
    {
        // Arrange
        HttpResponseMessage response = new(HttpStatusCode.OK)
        {
            Content = new StringContent("not json")
        };
        HttpClient httpClient = CreateMockHttpClient(response);
        AccountManager manager = new(httpClient);

        // Act
        RefreshTokenResponseDto result = await manager.RefreshTokenAsync(new RefreshTokenRequestDto());

        // Assert
        Assert.Null(result.JwtToken);
        Assert.Null(result.RefreshToken);
        Assert.Contains("Failed to parse refresh token response.", result.ErrorMessages!);
    }
}
