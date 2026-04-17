// Copyright (c) 2026 Team6. All rights reserved. 
//  No warranty, explicit or implicit, provided.

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using WebUI.Client.Services;

namespace WebUI.Client;

internal class Program
{
    private static async Task Main(string[] args)
    {
        WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);
        _ = builder.Services.AddScoped<TokenStorageService>();
        _ = builder.Services.AddScoped<AuthService>();

        await builder.Build().RunAsync();
    }
}
