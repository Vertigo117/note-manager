namespace NoteManager.Domain.Models.Entities;

/// <summary>
/// Заметка
/// </summary>
public class NoteEntity : BaseEntity
{
    /// <summary>
    /// Название
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Текст
    /// </summary>
    public string? Text { get; set; }

    /// <summary>
    /// Уникальный идентификатор пользователя
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// Навигационное свойство для связи с сущностью <see cref="UserEntity"/>
    /// </summary>
    public UserEntity User { get; set; } = null!;
}