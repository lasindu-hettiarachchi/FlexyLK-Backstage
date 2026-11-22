
using System.ComponentModel.DataAnnotations;

namespace FlexyLKB.Api.Models;

public class UserAccount
{
    public int UserId { get; set; }

    [Required]
    [MaxLength(100)]
    public string Username { get; set; } = string.Empty;

    [Required]
    [MaxLength(255)]
    public string PasswordHash { get; set; } = string.Empty;

    [Required]
    [MaxLength(30)]
    public string Role { get; set; } = "Customer";

    // Foreign Key - Client
    public int? ClientId { get; set; }

    // Navigation Property
    public Client? Client { get; set; }
}
