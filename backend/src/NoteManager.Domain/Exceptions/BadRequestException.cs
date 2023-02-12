namespace NoteManager.Domain.Exceptions;

/// <summary>
/// Represents the bad request exception.
/// </summary>
public sealed class BadRequestException : DomainException
{
    /// <summary>
    /// Initializes a new instance of a <see cref="BadRequestException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">Error message</param>
    public BadRequestException(string message) : base(message)
    { }
}