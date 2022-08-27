using NoteManager.Domain.Models.Entities;
using NoteManager.Domain.Repositories;

namespace NoteManager.Storage.PostgreSql.Repositories;

/// <inheritdoc cref="IUserEntityRepository"/>
internal class UserEntityRepository : BaseEntityRepository<UserEntity>, IUserEntityRepository
{
    public UserEntityRepository(NoteDbContext noteDbContext) : base(noteDbContext)
    {
    }
}