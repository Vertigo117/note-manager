using NoteManager.Domain.Abstractions.Primitives;

namespace NoteManager.Domain.Models.Entities;

/// <summary>
/// Represents a textual note
/// </summary>
public sealed class Note : Entity
{
    /// <summary>
    /// Initializes a new instance of a <see cref="Note"/> class.
    /// </summary>
    /// <remarks>
    /// Required by EF Core
    /// </remarks>
    private Note()
    { }

    /// <summary>
    /// Initializes a new instance of a <see cref="Note"/> class with the specified values.
    /// </summary>
    /// <param name="id">The note identifier.</param>
    /// <param name="title">The note title.</param>
    /// <param name="content">The note content.</param>
    internal Note(Guid id, string title, string content) : base(id)
    {
        Title = title;
        Content = content;
        CreationDate = DateTime.Now;
    }

    /// <summary>
    /// Gets the note title.
    /// </summary>
    public string Title { get; private set; }

    /// <summary>
    /// Gets the note content.
    /// </summary>
    public string Content { get; private set; }

    /// <summary>
    /// Gets the note creation date.
    /// </summary>
    public DateTime CreationDate { get; private set; }
}