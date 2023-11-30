using Microsoft.EntityFrameworkCore;
using Stores.Domain.Entity;

namespace Stores.Persistence;

public sealed class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        Database.Migrate();
    }

    public DbSet<Store> Stores { get; set; } = null!;
    public DbSet<Address> Addresses { get; set; } = null!;
    public DbSet<WorkingHours> WorkingHours { get; set; } = null!;
    public DbSet<Administrator> Administrators { get; set; } = null!;
    public DbSet<StoreType> StoreTypes { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Store>()
            .HasMany(s => s.Addresses)
            .WithOne(a => a.Store)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Store>()
            .HasOne(s => s.Administrator)
            .WithMany(a => a.Stores);

        modelBuilder.Entity<Store>()
            .HasOne(s => s.StoreType)
            .WithMany(st => st.Stores);

        modelBuilder.Entity<Store>()
            .HasOne(s => s.WorkingHours)
            .WithMany(wh => wh.Stores);
        
        modelBuilder.Entity<WorkingHours>()
            .HasMany(s => s.Stores)
            .WithOne(a => a.WorkingHours)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Administrator>()
            .HasMany(s => s.Stores)
            .WithOne(a => a.Administrator)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<StoreType>()
            .HasMany(s => s.Stores)
            .WithOne(a => a.StoreType)
            .OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(modelBuilder);
    }
}