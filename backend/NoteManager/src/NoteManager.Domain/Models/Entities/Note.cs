namespace NoteManager.Domain.Models.Entities;

/// <summary>
/// Заметка
/// </summary>
public sealed class Note : Entity
{
    /// <summary>
    /// Заголовок
    /// </summary>
    public string Title { get; set; } = null!;

    /// <summary>
    /// Текст
    /// </summary>
    public string? Text { get; set; }

    /// <summary>
    /// Уникальный идентификатор пользователя
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Навигационное свойство для связи с сущностью <see cref="Entities.User"/>
    /// </summary>
    public User User { get; set; } = null!;
}