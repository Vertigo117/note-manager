namespace NoteManager.Domain.Models.Entities;

/// <summary>
/// Сущность предметной области
/// </summary>
public abstract class Entity
{
    /// <summary>
    /// Уникальный идентификатор
    /// </summary>
    public Guid Id { get; set; } = default!;

    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTime CreationDate { get; set; }

    /// <summary>
    /// Дата последнего обновления
    /// </summary>
    public DateTime? UpdateDate { get; set; }
}