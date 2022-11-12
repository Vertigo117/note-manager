using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NoteManager.Domain.Abstractions.Interfaces.Repositories;
using NoteManager.Infrastructure.Storage.PostgreSql.Options;
using NoteManager.Infrastructure.Storage.PostgreSql.Repositories;
using NoteManager.Infrastructure.Storage.PostgreSql.Seed;

namespace NoteManager.Infrastructure.Storage.PostgreSql;

/// <summary>
/// Методы расширения для регистрации зависимостей
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Регистрация зависимостей слоя доступа к данным
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection"/> для доступа к сервисам</param>
    public static void AddPostgreSqlStorage(this IServiceCollection services)
    {
        services.ConfigureOptions<DatabaseOptionsSetup>();

        services.AddDbContextFactory<NoteManagerDbContext>((provider, builder) =>
        {
            var databaseOptions = provider.GetRequiredService<IOptions<DatabaseOptions>>().Value;

            builder.UseNpgsql(databaseOptions.ConnectionString, optionsBuilder =>
            {
                optionsBuilder.EnableRetryOnFailure(databaseOptions.MaxRetryCount);
                optionsBuilder.CommandTimeout(databaseOptions.CommandTimeout);
                optionsBuilder.MigrationsHistoryTable("__EFMigrationsHistory", NoteManagerDbContext.Schema);
            });

            builder.EnableDetailedErrors(databaseOptions.EnableDetailedErrors);
            builder.EnableSensitiveDataLogging(databaseOptions.EnableSensitiveDataLogging);
        });

        services.AddScoped<IDatabaseMigrator, DatabaseMigrator>();
        services.AddScoped<IDatabaseSeeder, DatabaseSeeder>();
        services.AddScoped<IRepositoryManager, RepositoryManager>();
    }
}