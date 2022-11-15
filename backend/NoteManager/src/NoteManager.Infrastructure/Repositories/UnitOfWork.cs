using NoteManager.Domain.Abstractions.Interfaces.Repositories;

namespace NoteManager.Infrastructure.Repositories;

/// <inheritdoc />
internal class UnitOfWork : IUnitOfWork
{
    private readonly NoteManagerDbContext _noteDbContext;

    public UnitOfWork(NoteManagerDbContext noteDbContext)
    {
        _noteDbContext = noteDbContext;
    }

    public Task<int> SaveChangesAsync()
    {
        return _noteDbContext.SaveChangesAsync();
    }
}