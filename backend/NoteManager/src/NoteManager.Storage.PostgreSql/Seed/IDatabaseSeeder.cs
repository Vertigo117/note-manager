namespace NoteManager.Storage.PostgreSql.Seed;

/// <summary>
/// Заполняет базу данных начальными значениями
/// </summary>
public interface IDatabaseSeeder
{
    /// <summary>
    /// Заполнить базу данных начальными значениями
    /// </summary>
    void SeedData();
}