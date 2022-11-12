namespace NoteManager.Application.Contracts;

/// <summary>
/// Объект передачи данных для постраничного вывода заметок
/// </summary>
public class NotePageDto
{
    /// <summary>
    /// Сущности на странице
    /// </summary>
    public NoteDto[] Content { get; init; } = Array.Empty<NoteDto>();

    /// <summary>
    /// Количество элементов на странице
    /// </summary>
    public int ContentSize { get; init; }
    
    /// <summary>
    /// Номер страницы
    /// </summary>
    public int PageNumber { get; init; }

    /// <summary>
    /// Общее количество элементов
    /// </summary>
    public int Total { get; init; }
}