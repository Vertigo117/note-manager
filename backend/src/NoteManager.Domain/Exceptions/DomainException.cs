namespace NoteManager.Domain.Exceptions;

/// <summary>
/// Represents the base class that all domain exceptions derive from.
/// </summary>
public abstract class DomainException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DomainException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The message, containing error details.</param>
    protected DomainException(string message) : base(message)
    { }
}