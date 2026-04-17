// Copyright (c) 2026 Team6. All rights reserved. 
//  No warranty, explicit or implicit, provided.

using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace WebUI.Client;

internal class Program
{
    private static async Task Main(string[] args)
    {
        WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);
        _ = builder.Services.AddScoped<TokenStorageService>();
        _ = builder.Services.AddScoped<JwtAuthenticationStateProvider>();
        _ = builder.Services.AddScoped<AuthenticationStateProvider>(sp => sp.GetRequiredService<JwtAuthenticationStateProvider>());
        _ = builder.Services.AddScoped<JwtAuthorizationMessageHandler>();
        _ = builder.Services.AddScoped(sp =>
        {
            JwtAuthorizationMessageHandler handler = sp.GetRequiredService<JwtAuthorizationMessageHandler>();
            HttpClient httpClient = new(handler)
            {
                BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
            };
            return httpClient;
        });
        _ = builder.Services.AddScoped<WebUI.Client.AuthService>();
        await builder.Build().RunAsync();
    }
}
