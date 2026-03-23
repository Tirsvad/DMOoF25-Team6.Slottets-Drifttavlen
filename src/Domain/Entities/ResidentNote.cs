// Copyright (c) 2026 Team6. All rights reserved. 
//  No warranty, explicit or implicit, provided.

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Domain.Interfaces;

namespace Domain.Entities;

public class ResidentNote : IEntity
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string Content { get; set; } = string.Empty;
    [Required]
    public DateTime CreatedAt { get; set; }
    public DateTime? EditedAt { get; set; }
    [ForeignKey("Resident")]
    public Guid ResidentId { get; set; }
    public Resident? Resident { get; set; }
}