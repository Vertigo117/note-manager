using NoteManager.Domain.Abstractions.Primitives;
using NoteManager.Domain.Exceptions;

namespace NoteManager.Domain.Models.ValueObjects;

/// <summary>
/// Represents the login value object.
/// </summary>
public class Login : ValueObject
{
    private const int MaxLength = 50;

    /// <summary>
    /// Initializes a new instance of the <see cref="Login"/> class with the specified value.
    /// </summary>
    /// <param name="value">The login value.</param>
    private Login(string value)
    {
        Value = value;
    }
    
    /// <summary>
    /// Gets the login value.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Creates a new instance of the <see cref="Login"/> class based on a specified value.
    /// </summary>
    /// <param name="value">The login value.</param>
    /// <returns>Login with a specified value.</returns>
    /// <exception cref="BadRequestException">Thrown when the specified login value is invalid.</exception>
    public static Login Create(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new BadRequestException($"Login value cannot be null or empty.");
        }

        if (value.Length > MaxLength)
        {
            throw new BadRequestException($"Login value cannot be longer than {MaxLength} characters.");
        }

        return new Login(value);
    }

    /// <inheritdoc />
    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}