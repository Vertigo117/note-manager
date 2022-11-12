using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace NoteManager.Infrastructure.Storage.PostgreSql;

/// <summary>
/// Выполняет миграцию данных
/// </summary>
public interface IDatabaseMigrator
{
    /// <summary>
    /// Выполняет миграцию
    /// </summary>
    void Migrate();
}

/// <inheritdoc />
internal class DatabaseMigrator : IDatabaseMigrator
{
    private readonly NoteManagerDbContext _context;
    private readonly ILogger<DatabaseMigrator> _logger;

    public DatabaseMigrator(NoteManagerDbContext context, ILogger<DatabaseMigrator> logger)
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