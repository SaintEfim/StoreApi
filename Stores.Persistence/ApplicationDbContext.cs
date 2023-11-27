using Microsoft.EntityFrameworkCore;
using Stores.Domain.Entity;

namespace Stores.Persistence;

public sealed class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        Database.Migrate();
    }

    public DbSet<Store> Stores { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<WorkingHours> WorkingHours { get; set; }
    public DbSet<Administrator> Administrators { get; set; }
    public DbSet<StoreType> StoreTypes { get; set; }

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

        base.OnModelCreating(modelBuilder);
    }
}