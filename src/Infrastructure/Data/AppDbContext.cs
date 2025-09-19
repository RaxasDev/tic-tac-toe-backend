using System.Reflection;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
    
    public override int SaveChanges()
    {
        ApplyTimestamps();
        return base.SaveChanges();
    }
    
    private void ApplyTimestamps()
    {
        var brazilTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(
            DateTime.UtcNow, "E. South America Standard Time"
        );

        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.Created = brazilTime;
                entry.Entity.Updated = brazilTime;
            }
            else if (entry.State == EntityState.Modified)
            {
                entry.Entity.Updated = brazilTime;
                if (entry.Entity.Created == default)
                    entry.Entity.Created = brazilTime;
            }
        }
    }
}