namespace NoteManager.Domain.Models;

/// <summary>
/// Заметка
/// </summary>
public class Note : Entity
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
    /// Навигационное свойство для связи с сущностью <see cref="Models.User"/>
    /// </summary>
    public User User { get; set; } = null!;
}