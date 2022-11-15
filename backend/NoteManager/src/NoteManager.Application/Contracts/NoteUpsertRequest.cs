using NoteManager.Domain.Models.Entities;

namespace NoteManager.Application.Contracts;

/// <summary>
/// Объект передачи данных для создания и обновления сущности <see cref="Note"/>
/// </summary>
public class NoteUpsertRequest
{
    /// <summary>
    /// Заголовок заметки
    /// </summary>
    public string Title { get; init; } = null!;

    /// <summary>
    /// Текст заметки
    /// </summary>
    public string Text { get; init; } = null!;
}