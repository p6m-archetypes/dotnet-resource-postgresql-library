using Microsoft.EntityFrameworkCore;

namespace {{ PrefixName }}{{ SuffixName }}.Resources;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // TODO: Add DbSets here
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
