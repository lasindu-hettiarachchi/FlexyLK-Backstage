
using System.ComponentModel.DataAnnotations;

namespace FlexyLKB.Api.Models;

public class Vehicle
{
    public int VehicleId { get; set; }

    // Foreign Key - Client
    public int ClientId { get; set; }

    [Required]
    [MaxLength(20)]
    public string PlateNumber { get; set; } = string.Empty;

    [MaxLength(100)]
    public string? Model { get; set; }

    public int? Year { get; set; }

    // Navigation Property
    public Client? Client { get; set; }
}
