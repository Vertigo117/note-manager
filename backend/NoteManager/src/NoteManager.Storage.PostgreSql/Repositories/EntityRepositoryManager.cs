using NoteManager.Domain.Repositories;

namespace NoteManager.Storage.PostgreSql.Repositories;

/// <inheritdoc />
internal class EntityRepositoryManager : IUnitOfWork
{
    private readonly NoteDbContext _noteDbContext;

    public EntityRepositoryManager(NoteDbContext noteDbContext, IUserEntityRepository users, INoteEntityRepository notes)
    {
        _noteDbContext = noteDbContext;
        Users = users;
        Notes = notes;
    }

    public IUserEntityRepository Users { get; }
    public INoteEntityRepository Notes { get; }
    
    public async Task SaveChangesAsync()
    {
        await _noteDbContext.SaveChangesAsync();
    }
}