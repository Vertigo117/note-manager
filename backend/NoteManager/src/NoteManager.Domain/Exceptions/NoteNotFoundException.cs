namespace NoteManager.Domain.Exceptions;

public class NoteNotFoundException : NotFoundException
{
    public NoteNotFoundException(Guid noteId) : base($"The user with the identifier {noteId} was not found.")
    { }
}