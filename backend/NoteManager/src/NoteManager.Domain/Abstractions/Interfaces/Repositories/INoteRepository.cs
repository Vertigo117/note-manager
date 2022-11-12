using NoteManager.Domain.Models.Entities;

namespace NoteManager.Domain.Abstractions.Interfaces.Repositories;

/// <summary>
/// Репозиторий для доступа к данным сущности <see cref="Note"/>
/// </summary>
public interface INoteRepository : IEntityRepository<Note>, IPagingRepository<Note>
{ }