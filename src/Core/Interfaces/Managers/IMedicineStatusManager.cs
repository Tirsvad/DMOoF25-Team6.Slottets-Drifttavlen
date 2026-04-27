// Copyright (c) 2026 Team6. All rights reserved. 
//  No warranty, explicit or implicit, provided.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.DTOs;

namespace Core.Interfaces.Managers;

/// <summary>
/// Defines infrastructure-level operations for retrieving medicine and painkiller status.
/// </summary>

public interface IMedicineStatusManager
{


    /// <summary>
    /// Retrieves medicine status for a resident for the last 24 hours.
    /// </summary>
    Task<MedicineStatusDto?> GetMedicineStatusAsync(Guid residentId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves painkiller status for a resident.
    /// </summary>
    Task<PainkillerStatusDto?> GetPainkillerStatusAsync(Guid residentId, CancellationToken cancellationToken = default);

}
