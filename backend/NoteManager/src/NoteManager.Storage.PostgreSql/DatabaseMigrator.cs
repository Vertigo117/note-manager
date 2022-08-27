using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace NoteManager.Storage.PostgreSql;

/// <summary>
/// Выполняет миграцию базы данных
/// </summary>
public interface IDatabaseMigrator
{
    /// <summary>
    /// Выполнить миграцию
    /// </summary>
    void Migrate();
}

/// <inheritdoc />
internal class DatabaseMigrator : IDatabaseMigrator
{
    private readonly NoteDbContext _context;
    private readonly ILogger<DatabaseMigrator> _logger;

    public DatabaseMigrator(NoteDbContext context, ILogger<DatabaseMigrator> logger)
    {
        _context = context;
        _logger = logger;
    }

    public void Migrate()
    {
        _logger.LogInformation("Initiating database migration...");

        try
        {
            _context.Database.Migrate();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Database migration failed. Error message: {message}", ex.Message);
        }
        
        _logger.LogInformation("Database migration complete.");
    }
}