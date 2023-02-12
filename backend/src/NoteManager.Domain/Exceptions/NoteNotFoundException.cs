namespace NoteManager.Domain.Exceptions;

/// <summary>
/// The exception that is thrown when note entity with a specified identifier was not found.
/// </summary>
public class NoteNotFoundException : DomainException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NoteNotFoundException"/> class with a specified error message,
    /// containing the identifier of the entity which was not found.
    /// </summary>
    /// <param name="noteId">The identifier of the note which was not found.</param>
    public NoteNotFoundException(Guid noteId) : base($"The note with the identifier {noteId} was not found.")
    { }
}