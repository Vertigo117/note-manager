using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace NoteManager.Infrastructure.Storage.PostgreSql.Options;

/// <summary>
/// Инициализация настроек базы данных
/// </summary>
internal class DatabaseOptionsSetup : IConfigureOptions<DatabaseOptions>
{
    private readonly IConfiguration _configuration;
    
    private const string ConfigurationSectionName = "DatabaseOptions";

    public DatabaseOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(DatabaseOptions options)
    {
        var connectionString = _configuration.GetConnectionString("DefaultConnection");

        options.ConnectionString = connectionString!;

        _configuration.GetSection(ConfigurationSectionName).Bind(options);
    }
}