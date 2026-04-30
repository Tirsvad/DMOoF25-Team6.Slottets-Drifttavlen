// Copyright (c) 2026 Team6. All rights reserved. 
//  No warranty, explicit or implicit, provided.

namespace Infrastructure.Data.Persistent.Views;

public class MedicineStatusView
{
    public Guid ResidentId { get; set; }
    public string Name { get; set; } = string.Empty;
    public int ActiveMedicines { get; set; }

}
