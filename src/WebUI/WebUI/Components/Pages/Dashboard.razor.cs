// Copyright (c) 2026 Team6. All rights reserved. 
//  No warranty, explicit or implicit, provided.

using Domain.Entities;

namespace WebUI.Components.Pages;

public partial class Dashboard
{
    private List<Resident> _residents = [];

    protected override async Task OnInitializedAsync()
    {
        _residents = (await ResidentService.GetAllAsync()).ToList();
    }

    //TODO: Replace with real timestamp in LastUpdated and update it when traffic light changes
}