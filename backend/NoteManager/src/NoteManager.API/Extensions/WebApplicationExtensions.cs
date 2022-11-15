using NoteManager.Infrastructure;

namespace NoteManager.API.Extensions;

/// <summary>
/// Содержит методы расширений для класса <see cref="WebApplication"/>
/// </summary>
public static class WebApplicationExtensions
{
    /// <summary>
    /// Применяет миграции к базе данных
    /// </summary>
    /// <param name="webApplication"><see cref="WebApplication"/> для настройки пайплайна HTTP и доступа
    /// к сервисам</param>
    public static void MigrateDatabase(this WebApplication webApplication)
    {
        using var scope = webApplication.Services.CreateScope();

        var databaseMigrator = scope.ServiceProvider.GetRequiredService<IDatabaseMigrator>();
        
        databaseMigrator.Migrate();
    }
}