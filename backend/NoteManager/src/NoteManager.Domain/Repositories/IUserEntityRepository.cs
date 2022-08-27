using NoteManager.Domain.Models.Entities;

namespace NoteManager.Domain.Repositories;

/// <summary>
/// Репозиторий для доступа к данным пользователя
/// </summary>
public interface IUserEntityRepository : IEntityRepository<UserEntity>, IPagedEntityRepository<UserEntity>
{
}