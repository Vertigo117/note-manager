using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NoteManager.Domain.Abstractions.Interfaces.Repositories;
using NoteManager.Domain.Models.Entities;

namespace NoteManager.Infrastructure.Repositories;

/// <inheritdoc />
internal abstract class EntityRepository<TEntity> : IEntityRepository<TEntity> where TEntity : Entity
{
    protected readonly NoteManagerDbContext NoteDbContext;

    protected EntityRepository(NoteManagerDbContext noteDbContext)
    {
        NoteDbContext = noteDbContext;
    }
    
    public void Add(TEntity entity)
    {
        NoteDbContext.Add(entity);
    }

    public ValueTask<TEntity?> FindAsync(Guid id)
    {
        return NoteDbContext.Set<TEntity>().FindAsync(id);
    }

    public Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression)
    {
        return NoteDbContext.Set<TEntity>().FirstOrDefaultAsync(expression);
    }

    public Task<TEntity[]> GetAllAsync()
    {
        return NoteDbContext.Set<TEntity>().ToArrayAsync();
    }

    public Task<TEntity[]> GetByExpressionAsync(Expression<Func<TEntity, bool>> expression)
    {
        return NoteDbContext.Set<TEntity>().Where(expression).ToArrayAsync();
    }

    public void Update(TEntity entity)
    {
        NoteDbContext.Update(entity);
    }

    public void Remove(TEntity entity)
    {
        NoteDbContext.Remove(entity);
    }
}