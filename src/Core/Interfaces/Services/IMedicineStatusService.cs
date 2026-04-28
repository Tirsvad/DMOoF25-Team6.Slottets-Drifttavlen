// Copyright (c) 2026 Team6. All rights reserved. 
//  No warranty, explicit or implicit, provided.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.DTOs;

namespace Core.Interfaces.Services;

/// <summary>
/// Defines a contract for retrieving medicine and painkiller status for a resident.
/// </summary>
/// <remarks>
/// This service is used by the UI layer to fetch medicine-related data.
/// </remarks>

public interface IMedicineStatusService
{
    /// <summary>
    /// Retrieves medicine status for a resident for the last 24 hours.
    /// </summary>
    /// <param name="residentId">The unique identifier of the resident.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A <see cref="MedicineStatusDto"/> containing medicine status data.</returns>
    Task<MedicineStatusDto?> GetMedicineStatusAsync(Guid residentId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves painkiller status for a resident.
    /// </summary>
    /// <param name="residentId">The unique identifier of the resident.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A <see cref="PainkillerStatusDto"/> containing painkiller status data.</returns>
    Task<PainkillerStatusDto?> GetPainkillerStatusAsync(Guid residentId, CancellationToken cancellationToken = default);

}
