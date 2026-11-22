
using Microsoft.EntityFrameworkCore;
using FlexyLKB.Api.Models;

namespace FlexyLKB.Api.Database;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Client> Clients { get; set; }

    public DbSet<Vehicle> Vehicles { get; set; }

    public DbSet<UserAccount> UserAccounts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // One Client has many Vehicles
        modelBuilder.Entity<Client>()
            .HasMany(c => c.Vehicles)
            .WithOne(v => v.Client)
            .HasForeignKey(v => v.ClientId);

        // One Client has one UserAccount
        modelBuilder.Entity<Client>()
            .HasOne(c => c.UserAccount)
            .WithOne(u => u.Client)
            .HasForeignKey<UserAccount>(u => u.ClientId);

        // Unique email and vehicle plate number
        modelBuilder.Entity<Client>()
            .HasIndex(c => c.Email)
            .IsUnique();

        modelBuilder.Entity<Vehicle>()
            .HasIndex(v => v.PlateNumber)
            .IsUnique();
    }
}
