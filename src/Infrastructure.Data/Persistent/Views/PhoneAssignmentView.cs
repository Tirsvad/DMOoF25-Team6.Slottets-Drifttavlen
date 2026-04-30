// Copyright (c) 2026 Team6. All rights reserved.
// No warranty, explicit or implicit, provided.

using System.ComponentModel.DataAnnotations.Schema;

using Domain.Entities;

namespace Infrastructure.Data.Persistent.Views;

/// <summary>
/// Read model for the vwPhoneAssignment database view.
/// Represents a phone assignment joined with caregiver information.
/// This is not a domain entity - it is a read-only projection.
/// </summary>
public sealed class PhoneAssignmentView
{
    public Guid Id { get; init; }
    public string PhoneNumber { get; init; } = string.Empty;
    public string ShiftType { get; init; } = string.Empty;
    [ForeignKey(nameof(Employee))]
    public Guid EmployeeId { get; init; }
    public string EmployeeName { get; init; } = string.Empty;
}
