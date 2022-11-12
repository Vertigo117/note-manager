namespace NoteManager.Domain.Abstractions.Interfaces.Repositories;

/// <summary>
/// Обеспечивает транзакционную безопасность доступа к данным
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// Асинхронно сохраняет изменения в контексте данных
    /// </summary>
    /// <returns>Результат выполнения асинхронной операции. Результатом является число записей, подвергшихся
    /// изменению</returns>
    Task<int> SaveChangesAsync();
}