namespace NoteManager.Domain.Repositories;

/// <summary>
/// Обеспечивает транзакционную безопасность доступа к данным
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// Репозиторий пользователей
    /// </summary>
    public IUserEntityRepository Users { get; }

    /// <summary>
    /// Репозиторий заметок
    /// </summary>
    public INoteEntityRepository Notes { get; }
    
    /// <summary>
    /// Сохранить изменения
    /// </summary>
    /// <returns>Результат выполнения асинхронной операции</returns>
    Task SaveChangesAsync();
}