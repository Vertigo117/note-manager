namespace NoteManager.Domain.Models;

/// <summary>
/// Доменная сущность
/// </summary>
public abstract class Entity
{
    /// <summary>
    /// Уникальный идентификатор
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTime CreationDate { get; set; }

    /// <summary>
    /// Дата последнего обновления
    /// </summary>
    public DateTime? UpdateDate { get; set; }
}