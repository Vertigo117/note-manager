namespace NoteManager.Domain.Entities;

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
    /// Навигационное свойство для связи с сущностью <see cref="UserEntity"/>
    /// </summary>
    public UserEntity User { get; set; } = null!;
}