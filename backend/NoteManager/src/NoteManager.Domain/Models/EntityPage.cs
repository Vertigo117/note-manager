using NoteManager.Domain.Models.Entities;

namespace NoteManager.Domain.Models;

/// <summary>
/// Модель для постраничного вывода экземпляров сущности
/// </summary>
/// <typeparam name="TEntity">Тип сущности</typeparam>
public class EntityPage<TEntity> where TEntity : Entity
{
    /// <summary>
    /// Содержимое страницы
    /// </summary>
    public TEntity[] Content { get; init; } = Array.Empty<TEntity>();

    /// <summary>
    /// Количество элементов на странице
    /// </summary>
    public int ContentSize { get; init; }
    
    /// <summary>
    /// Номер страницы
    /// </summary>
    public int Number => (int) Math.Ceiling((decimal) Total / ContentSize);

    /// <summary>
    /// Общее количество элементов
    /// </summary>
    public int Total { get; init; }
}