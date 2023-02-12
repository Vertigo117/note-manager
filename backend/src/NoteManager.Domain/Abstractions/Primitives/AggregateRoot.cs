namespace NoteManager.Domain.Abstractions.Primitives;

/// <summary>
/// Represents the aggregate root.
/// </summary>
public abstract class AggregateRoot : Entity
{
    private readonly List<IDomainEvent> _domainEvents = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="AggregateRoot"/> class.
    /// </summary>
    /// <remarks>
    /// Required by EF Core.
    /// </remarks>
    protected AggregateRoot()
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="AggregateRoot"/> class.
    /// </summary>
    /// <param name="id">The aggregate root identifier.</param>
    protected AggregateRoot(Guid id) : base(id)
    { }

    /// <summary>
    /// Adds domain event to entity.
    /// </summary>
    /// <param name="event">Domain event.</param>
    protected void AddDomainEvent(IDomainEvent @event)
    {
        _domainEvents.Add(@event);
    }

    /// <summary>
    /// Gets all domain events from entity.
    /// </summary>
    /// <returns>A collection of domain events.</returns>
    public IEnumerable<IDomainEvent> GetDomainEvents()
    {
        return _domainEvents;
    }

    /// <summary>
    /// Removes all domain events from entity.
    /// </summary>
    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}