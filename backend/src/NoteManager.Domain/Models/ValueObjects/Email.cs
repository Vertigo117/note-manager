using System.Text.RegularExpressions;
using NoteManager.Domain.Abstractions.Primitives;
using NoteManager.Domain.Exceptions;

namespace NoteManager.Domain.Models.ValueObjects;

/// <summary>
/// Represents the email value object.
/// </summary>
public class Email : ValueObject
{
    private const int MaxLength = 50;

    private const string EmailRegexPattern =
        @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

    private static readonly Lazy<Regex> EmailFormatRegex =
        new(() => new Regex(EmailRegexPattern, RegexOptions.Compiled | RegexOptions.IgnoreCase));

    public string Value { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Email"/> class with the specified value.
    /// </summary>
    /// <param name="value">The email value.</param>
    private Email(string value)
    {
        Value = value;
    }

    /// <summary>
    /// Creates a new instance of the <see cref="Email"/> class based on the specified value
    /// </summary>
    /// <param name="email">The email value.</param>
    /// <returns>Email with a specified value.</returns>
    /// <exception cref="BadRequestException">Thrown when email has invalid value</exception>
    public static Email Create(string email)
    {
        if (string.IsNullOrEmpty(email))
        {
            throw new BadRequestException("Email value cannot be empty.");
        }

        if (email.Length > MaxLength)
        {
            throw new BadRequestException($"Email value cannot be longer than {MaxLength} characters");
        }

        if (!EmailFormatRegex.Value.IsMatch(email))
        {
            throw new BadRequestException("Email value contains invalid characters.");
        }

        return new Email(email);
    }

    /// <inheritdoc />
    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}