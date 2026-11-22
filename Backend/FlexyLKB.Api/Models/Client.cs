
using System.ComponentModel.DataAnnotations;

namespace FlexyLKB.Api.Models;

public class Client
{
    public int ClientId { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(150)]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [MaxLength(20)]
    public string? Phone { get; set; }

    // One Client can have many Vehicles
    public ICollection<Vehicle> Vehicles { get; set; }
        = new List<Vehicle>();

    // A Client can have one UserAccount
    public UserAccount? UserAccount { get; set; }
}
