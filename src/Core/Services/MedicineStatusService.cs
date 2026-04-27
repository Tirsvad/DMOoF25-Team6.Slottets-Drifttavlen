// Copyright (c) 2026 Team6. All rights reserved. 
//  No warranty, explicit or implicit, provided.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.DTOs;
using Core.Interfaces.Managers;
using Core.Interfaces.Services;

namespace Core.Services;

/// <summary>
/// Provides business logic for retrieving medicine and painkiller status.
/// </summary>


public class MedicineStatusService(IMedicineStatusManager medicineStatusManager) : IMedicineStatusService
{
    private readonly IMedicineStatusManager _medicineStatusManager = medicineStatusManager;

    /// <summary>
    /// Retrieves medicine status for a resident for the last 24 hours.
    /// </summary>
    /// <param name="residentId">The unique identifier of the resident.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A <see cref="MedicineStatusDto"/> containing medicine status data.</returns>
    public async Task<MedicineStatusDto?> GetMedicineStatusAsync(Guid residentId, CancellationToken cancellationToken = default)
    {
        return await _medicineStatusManager.GetMedicineStatusAsync(residentId, cancellationToken);
    }

    /// <summary>
    /// Retrieves painkiller status for a resident.
    /// </summary>
    /// <param name="residentId">The unique identifier of the resident.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A <see cref="PainkillerStatusDto"/> containing painkiller status data.</returns>
    public async Task<PainkillerStatusDto?> GetPainkillerStatusAsync(Guid residentId, CancellationToken cancellationToken = default)
    {
        return await _medicineStatusManager.GetPainkillerStatusAsync(residentId, cancellationToken);
    }

}
