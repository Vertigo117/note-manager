using NoteManager.Domain.Models.Entities;
using NoteManager.Domain.Repositories;

namespace NoteManager.Storage.PostgreSql.Repositories;

/// <inheritdoc cref="INoteEntityRepository"/>
internal class NoteEntityRepository : BaseEntityRepository<NoteEntity>, INoteEntityRepository
{
    public NoteEntityRepository(NoteDbContext noteDbContext) : base(noteDbContext)
    {
    }
}