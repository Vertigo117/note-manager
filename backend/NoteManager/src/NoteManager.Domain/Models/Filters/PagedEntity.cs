using NoteManager.Domain.Models.Entities;

namespace NoteManager.Domain.Models.Filters;

/// <summary>
/// Модель для постраничного вывода экземпляров сущности
/// </summary>
/// <typeparam name="TEntity">Тип сущности</typeparam>
public class PagedEntity<TEntity> where TEntity : BaseEntity
{
    /// <summary>
    /// Сущности на странице
    /// </summary>
    public TEntity[] Entities { get; init; } = Array.Empty<TEntity>();

    /// <summary>
    /// Количество элементов на странице
    /// </summary>
    public int PageSize { get; init; }
    
    /// <summary>
    /// Номер страницы
    /// </summary>
    public int PageNumber => (int) Math.Ceiling((decimal) Total / PageSize);

    /// <summary>
    /// Общее количество элементов
    /// </summary>
    public int Total { get; init; }
}