// Copyright (c) 2026 Team6. All rights reserved. 
//  No warranty, explicit or implicit, provided.

using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Components;

namespace WebUI.Client.Components.Pages;

public partial class Login
{
    [Inject]
    private AuthService AuthService { get; set; } = default!;

    [Inject]
    private NavigationManager Navigation { get; set; } = default!;

    private readonly LoginModel loginModel = new();
    private string? errorMessage;

    private async Task HandleLogin()
    {
        bool success = await AuthService.LoginAsync(loginModel.Username, loginModel.Password);
        if (!success)
        {
            errorMessage = "Ugyldigt brugernavn eller adgangskode.";
        }
        else
        {
            errorMessage = null;
            Navigation.NavigateTo(Navigation.Uri, new NavigationOptions { ForceLoad = true }); // Refresh UI
        }
    }

    private async Task Logout()
    {
        await AuthService.LogoutAsync();
        Navigation.NavigateTo(Navigation.Uri, new NavigationOptions { ForceLoad = true }); // Refresh UI
    }

    public class LoginModel
    {
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
