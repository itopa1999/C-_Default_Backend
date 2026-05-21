using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Backend.Domain.Common;
namespace Backend.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    public override int SaveChanges()
    {
        ApplyAuditRules();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        ApplyAuditRules();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void ApplyAuditRules()
    {
        var entries = ChangeTracker.Entries<BaseEntity>();

        foreach (var entry in entries)
        {
            var entity = entry.Entity;

            switch (entry.State)
            {
                case EntityState.Added:
                    entity.CreatedAt = DateTime.Now;
                    break;

                case EntityState.Modified:
                    entity.ModifiedAt = DateTime.Now;
                    break;

                case EntityState.Deleted:
                    // SOFT DELETE
                    entry.State = EntityState.Modified;
                    entity.IsDeleted = true;
                    entity.DeletedAt = DateTime.Now;
                    break;
            }
        }
    }
}