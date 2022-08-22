namespace NoteManager.Domain.Entities;

/// <summary>
/// Базовый класс сущности
/// </summary>
public abstract class BaseEntity
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