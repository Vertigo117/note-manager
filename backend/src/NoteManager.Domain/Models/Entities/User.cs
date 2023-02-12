using NoteManager.Domain.Abstractions.Primitives;
using NoteManager.Domain.Exceptions;
using NoteManager.Domain.Models.Enums;
using NoteManager.Domain.Models.ValueObjects;

namespace NoteManager.Domain.Models.Entities;

/// <summary>
/// Represents a user of the note-managing system
/// </summary>
public sealed class User : AggregateRoot
{
    private readonly List<Note> _notes = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="User"/> class.
    /// </summary>
    /// <remarks>
    /// Required by EF Core.
    /// </remarks>
    private User()
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="User"/> class with the specified values.
    /// </summary>
    /// <param name="id">The user identifier.</param>
    /// <param name="name">The user name</param>
    /// <param name="login">The user login.</param>
    /// <param name="email">The user email.</param>
    /// <param name="passwordHash">The user password hash.</param>
    /// <param name="role">The user role in the system.</param>
    private User(Guid id, Name name, Login login, Email email, string passwordHash, Role role) : base(id)
    {
        Name = name;
        Login = login;
        Email = email;
        PasswordHash = passwordHash;
        Role = role;
    }

    public Name Name { get; private set; }

    /// <summary>
    /// Gets the user full name.
    /// </summary>
    public string FullName => $"{Name.FirstName} {Name.LastName}";

    /// <summary>
    /// Gets the user login.
    /// </summary>
    public Login Login { get; private set; }

    /// <summary>
    /// Gets the user email.
    /// </summary>
    public Email Email { get; private set; }

    /// <summary>
    /// Gets the user password hash.
    /// </summary>
    public string PasswordHash { get; private set; }

    /// <summary>
    /// Gets the user role.
    /// </summary>
    public Role Role { get; private set; }

    /// <summary>
    /// Gets the user notes.
    /// </summary>
    public IEnumerable<Note> Notes => _notes;

    /// <summary>
    /// Creates a new user with specified parameters.
    /// </summary>
    /// <param name="firstName">The user first name.</param>
    /// <param name="lastName">The user last name.</param>
    /// <param name="login">The user login.</param>
    /// <param name="email">The user email.</param>
    /// <param name="passwordHash">The user password hash.</param>
    /// <param name="role">The user role in the system.</param>
    /// <returns>A user with specified parameters.</returns>
    public static User Create(string firstName,
        string lastName,
        string login,
        string email,
        string passwordHash,
        Role role)
    {
        return new User(Guid.NewGuid(),
            Name.Create(firstName, lastName),
            Login.Create(login),
            Email.Create(email),
            passwordHash,
            role);
    }

    /// <summary>
    /// Adds a new note with title and content to the user.
    /// </summary>
    /// <param name="title">The note title.</param>
    /// <param name="content">The note content.</param>
    public void AddNote(string title, string content)
    {
        var note = new Note(Guid.NewGuid(), title, content);

        _notes.Add(note);
    }

    /// <summary>
    /// Removes a note with a specified identifier.
    /// </summary>
    /// <param name="noteId">The note identifier.</param>
    /// <exception cref="NoteNotFoundException">Thrown when note is not found.</exception>
    public void RemoveNote(Guid noteId)
    {
        var note = Notes.FirstOrDefault(n => n.Id == noteId);

        if (note is null)
        {
            throw new NoteNotFoundException(noteId);
        }

        _notes.Remove(note);
    }
}