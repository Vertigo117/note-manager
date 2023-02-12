namespace NoteManager.Domain.Abstractions.Primitives;

/// <summary>
/// Represents a base class that all value objects derive from.
/// </summary>
public abstract class ValueObject
{
    /// <summary>
    /// Determines if two value objects are equal.
    /// </summary>
    /// <param name="left">Left operand.</param>
    /// <param name="right">Right operand.</param>
    /// <returns>True if both value objects are null, reference the same value or have the same value.
    /// False if only one of them is null, they reference different values or unequal by value.</returns>
    protected static bool EqualOperator(ValueObject? left, ValueObject? right)
    {
        if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
        {
            return false;
        }

        return ReferenceEquals(left, right) || (left is not null && left.Equals(right));
    }

    /// <summary>
    /// Determines if two value objects are not equal.
    /// </summary>
    /// <param name="left">Left operand.</param>
    /// <param name="right">Right operand.</param>
    /// <returns>True if <see cref="EqualOperator"/> returns false and otherwise.</returns>
    protected static bool NotEqualOperator(ValueObject? left, ValueObject? right)
    {
        return !EqualOperator(left, right);
    }

    public static bool operator ==(ValueObject? one, ValueObject? two)
    {
        return EqualOperator(one, two);
    }

    public static bool operator !=(ValueObject? one, ValueObject? two)
    {
        return NotEqualOperator(one, two);
    }

    /// <summary>
    /// Gets the atomic values of a value object's properties.
    /// </summary>
    /// <returns>A collection of values.</returns>
    protected abstract IEnumerable<object?> GetEqualityComponents();

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        if (obj is null || obj.GetType() != GetType())
        {
            return false;
        }

        var other = (ValueObject)obj;

        return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        return GetEqualityComponents()
            .Select(obj => obj is not null ? obj.GetHashCode() : 0)
            .Aggregate((x, y) => x ^ y); // Bitwise XOR
    }
}