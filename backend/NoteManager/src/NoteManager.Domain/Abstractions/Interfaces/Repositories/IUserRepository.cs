using NoteManager.Domain.Models.Entities;

namespace NoteManager.Domain.Abstractions.Interfaces.Repositories;

/// <summary>
/// Репозиторий для доступа к данным сущности <see cref="User"/>
/// </summary>
public interface IUserRepository : IEntityRepository<User>
{ }