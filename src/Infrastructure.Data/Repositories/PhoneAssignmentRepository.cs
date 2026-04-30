// Copyright (c) 2026 Team6. All rights reserved.
// No warranty, explicit or implicit, provided.

using Core.DTOs;
using Core.Interfaces.Repositories;

using Domain.Entities;

using Infrastructure.Data.Persistent;

using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories;

/// <summary>
/// Repository for managing phone assignments in the database.
/// </summary>
public class PhoneAssignmentRepository(AppDbContext dbContext)
    : Repository<PhoneAssignment>(dbContext), IPhoneAssignmentRepository
{
    private readonly AppDbContext _dbContext = dbContext;

    /// <inheritdoc/>
    public async Task<IEnumerable<PhoneAssignment>> GetByShiftTypeAsync(
        string shiftType, CancellationToken cancellationToken)
    {
        return await _dbContext.PhoneAssignments
            .Where(p => p.ShiftType == shiftType)
            .ToListAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<PhoneAssignmentDto>> GetDtoByShiftTypeAsync(
        string shiftType, CancellationToken cancellationToken)
    {
        // Use the vwPhoneAssignment view to get phone assignments with caregiver name
        //return await _dbContext.PhoneAssignmentView
        //    .Where(p => p.ShiftType == shiftType)
        //    .Select(p => new PhoneAssignmentDto
        //    {
        //        PhoneNumber = p.PhoneNumber,
        //        ShiftType = p.ShiftType,
        //        AssignedStaffName = p.CaregiverName
        //    })
        //    .ToListAsync(cancellationToken);


        // Use DTO instead of view, join PhoneAssignments with Users to get caregiver name
        return await _dbContext.PhoneAssignments
            .Where(p => p.ShiftType == shiftType)
            .Select(p => new PhoneAssignmentDto
            {
                PhoneNumber = p.PhoneNumber,
                ShiftType = p.ShiftType,
                AssignedStaffName = _dbContext.Users
                    .Where(u => u.Id == p.CaregiverId)
                    .Select(u => u.UserName)
                    .FirstOrDefault() ?? string.Empty
            })
            .ToListAsync(cancellationToken);
    }
}
