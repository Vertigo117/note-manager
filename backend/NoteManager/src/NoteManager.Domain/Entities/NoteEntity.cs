namespace NoteManager.Domain.Entities;

/// <summary>
/// Заметка
/// </summary>
public class NoteEntity : BaseEntity
{
    /// <summary>
    /// Название
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// Текст
    /// </summary>
    public string? Text { get; set; }

    /// <summary>
    /// Пользователь
    /// </summary>
    public UserEntity User { get; set; } = new();
}