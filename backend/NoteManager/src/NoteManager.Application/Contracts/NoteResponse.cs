using NoteManager.Domain.Models.Entities;

namespace NoteManager.Application.Contracts;

/// <summary>
/// Объект передачи данных для сущности <see cref="Note"/>
/// </summary>
public class NoteResponse
{
    /// <summary>
    /// Уникальный идентификатор
    /// </summary>
    public Guid Id { get; init; }
    
    /// <summary>
    /// Заголовок
    /// </summary>
    public string Title { get; init; } = null!;

    /// <summary>
    /// Текст
    /// </summary>
    public string? Text { get; init; }

    /// <summary>
    /// Уникальный идентификатор пользователя
    /// </summary>
    public int UserId { get; init; }
    
    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTime CreationDate { get; init; }

    /// <summary>
    /// Дата последнего обновления
    /// </summary>
    public DateTime? UpdateDate { get; init; }
}