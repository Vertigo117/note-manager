namespace NoteManager.Storage.PostgreSql.Options;

/// <summary>
/// Настройки базы данных
/// </summary>
internal class DatabaseOptions
{
    /// <summary>
    /// Строка подключения
    /// </summary>
    public string ConnectionString { get; set; } = null!;

    /// <summary>
    /// Максимальное количество повторных попыток
    /// </summary>
    public int MaxRetryCount { get; init; }

    /// <summary>
    /// Таймаут выполнения команд
    /// </summary>
    public int CommandTimeout { get; init; }

    /// <summary>
    /// Разрешить вывод подробной информации об ошибках
    /// </summary>
    public bool EnableDetailedErrors { get; init; }

    /// <summary>
    /// Разрешить отображение конфиденциальной информации в логах
    /// </summary>
    public bool EnableSensitiveDataLogging { get; init; }
}