using Microsoft.EntityFrameworkCore;

namespace {{ PrefixName }}{{ SuffixName }}.Resources;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // Consuming archetypes add entities via `public partial class AppDbContext` (DbSets, OnModelCreating).
    // public DbSet<YourEntity> YourEntities => Set<YourEntity>();
}

public static class PersistenceExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, Settings settings)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(settings.DatabaseUrl));
        return services;
    }
}
