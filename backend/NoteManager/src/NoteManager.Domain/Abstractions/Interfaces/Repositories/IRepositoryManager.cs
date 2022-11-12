namespace NoteManager.Domain.Abstractions.Interfaces.Repositories;

/// <summary>
/// Менеджер репозиториев
/// </summary>
public interface IRepositoryManager
{
    /// <summary>
    /// <inheritdoc cref="INoteRepository"/>
    /// </summary>
    public INoteRepository NoteRepository { get; }
    
    /// <summary>
    /// <inheritdoc cref="IUserRepository"/>
    /// </summary>
    public IUserRepository UserRepository { get; }
    
    /// <summary>
    /// <inheritdoc cref="IUnitOfWork"/>
    /// </summary>
    public IUnitOfWork UnitOfWork { get; }
}