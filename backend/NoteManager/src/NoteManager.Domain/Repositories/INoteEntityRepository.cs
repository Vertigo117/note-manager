using NoteManager.Domain.Models.Entities;

namespace NoteManager.Domain.Repositories;

/// <summary>
/// Репозиторий для доступа к данным заметок
/// </summary>
public interface INoteEntityRepository : IEntityRepository<NoteEntity>, IPagedEntityRepository<NoteEntity>
{
}