namespace NoteManager.Application.Contracts;

/// <summary>
/// Ответ на запрос, во время выполнения которого произошла ошибка
/// </summary>
public class ErrorResponse
{
    public string Message { get; init; } = null!;
}