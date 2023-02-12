using NoteManager.Domain.Abstractions.Primitives;
using NoteManager.Domain.Exceptions;

namespace NoteManager.Domain.Models.ValueObjects;

/// <summary>
/// Represents the user name value object.
/// </summary>
public class Name : ValueObject
{
    private const int MaxLength = 50;
    
    /// <summary>
    /// Gets the first name value.
    /// </summary>
    public string FirstName { get; }

    /// <summary>
    /// Gets the last name value.
    /// </summary>
    public string LastName { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Name"/> class with the specified values.
    /// </summary>
    /// <param name="firstName">The first name value.</param>
    /// <param name="lastName">The last name value.</param>
    private Name(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    /// <summary>
    /// Creates a new name with the specified first name and last name.
    /// </summary>
    /// <param name="firstName">The first name part of name.</param>
    /// <param name="lastName">The last name part of name.</param>
    /// <returns></returns>
    /// <exception cref="BadRequestException">Thrown when first name or last name do not meet the required
    /// constrains.</exception>
    public static Name Create(string firstName, string lastName)
    {
        if (string.IsNullOrEmpty(firstName))
        {
            throw new BadRequestException("First name cannot be null.");
        }

        if (string.IsNullOrEmpty(lastName))
        {
            throw new BadRequestException("Last name cannot be null.");
        }

        if (firstName.Length > MaxLength)
        {
            throw new BadRequestException($"First name cannot be longer than {MaxLength} characters.");
        }

        if (lastName.Length > MaxLength)
        {
            throw new BadRequestException($"Last name cannot be longer than {MaxLength} characters.");
        }

        return new Name(firstName, lastName);
    }

    /// <inheritdoc />
    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return FirstName;
        yield return LastName;
    }
}