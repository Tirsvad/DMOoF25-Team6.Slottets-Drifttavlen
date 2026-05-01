// Copyright (c) 2026 Team6. All rights reserved. 
//  No warranty, explicit or implicit, provided.

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Domain.Interfaces;

namespace Domain.Entities;

public class PainkillerRecord : IEntity
{
    [Key]
    public Guid Id { get; set; }
    [ForeignKey("Resident")]
    public Guid ResidentId { get; set; }
    public string Type { get; set; } = string.Empty;
    public DateTime GivenAt { get; set; }
    public DateTime NextAllowedTime { get; set; }
}
