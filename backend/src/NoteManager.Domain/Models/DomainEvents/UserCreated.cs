using NoteManager.Domain.Abstractions.Primitives;

namespace NoteManager.Domain.Models.DomainEvents;

/// <summary>
/// Represents a domain event raised when a user is created.
/// </summary>
/// <param name="Id">The user identifier.</param>
/// <param name="Email">The user email address.</param>
/// <param name="FullName">The user full name</param>
public record UserCreated(Guid Id, string Email, string FullName) : IDomainEvent;