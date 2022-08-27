using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NoteManager.Domain.Repositories;
using NoteManager.Storage.PostgreSql.Options;
using NoteManager.Storage.PostgreSql.Repositories;
using NoteManager.Storage.PostgreSql.Seed;

namespace NoteManager.Storage.PostgreSql;

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

        services.AddDbContextFactory<NoteDbContext>((provider, builder) =>
        {
            var databaseOptions = provider.GetRequiredService<IOptions<DatabaseOptions>>().Value;

            builder.UseNpgsql(databaseOptions.ConnectionString, optionsBuilder =>
            {
                optionsBuilder.EnableRetryOnFailure(databaseOptions.MaxRetryCount);
                optionsBuilder.CommandTimeout(databaseOptions.CommandTimeout);
                optionsBuilder.MigrationsHistoryTable("__EFMigrationsHistory", NoteDbContext.Schema);
            });

            builder.EnableDetailedErrors(databaseOptions.EnableDetailedErrors);
            builder.EnableSensitiveDataLogging(databaseOptions.EnableSensitiveDataLogging);
        });

        services.AddScoped<IDatabaseMigrator, DatabaseMigrator>();
        services.AddScoped<IDatabaseSeeder, DatabaseSeeder>();
        services.AddScoped<IUserEntityRepository, UserEntityRepository>();
        services.AddScoped<INoteEntityRepository, NoteEntityRepository>();
        services.AddScoped<IUnitOfWork, EntityRepositoryManager>();
    }
}