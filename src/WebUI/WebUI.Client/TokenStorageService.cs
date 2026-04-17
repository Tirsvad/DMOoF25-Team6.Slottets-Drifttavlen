// Copyright (c) 2026 Team6. All rights reserved. 
//  No warranty, explicit or implicit, provided.

using Microsoft.JSInterop;

namespace WebUI.Client;

/// <summary>
/// Service for storing and retrieving JWT tokens in browser local storage.
/// </summary>
public class TokenStorageService
{
    private readonly IJSRuntime _jsRuntime;
    private const string TokenKey = "jwt_token";

    public TokenStorageService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public ValueTask SetTokenAsync(string token)
        => _jsRuntime.InvokeVoidAsync("localStorage.setItem", TokenKey, token);

    public ValueTask<string?> GetTokenAsync()
        => _jsRuntime.InvokeAsync<string?>("localStorage.getItem", TokenKey);

    public ValueTask RemoveTokenAsync()
        => _jsRuntime.InvokeVoidAsync("localStorage.removeItem", TokenKey);
}
