using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NoteManager.Domain.Models.Entities;
using NoteManager.Domain.Models.Filters;
using NoteManager.Domain.Repositories;

namespace NoteManager.Storage.PostgreSql.Repositories;

/// <summary>
/// Базовая реализация репозитория доступа к данным
/// </summary>
/// <typeparam name="TEntity">Тип сущности</typeparam>
internal abstract class BaseEntityRepository<TEntity> : IEntityRepository<TEntity>, IPagedEntityRepository<TEntity> where 
TEntity : BaseEntity
{
    protected readonly NoteDbContext NoteDbContext;

    protected BaseEntityRepository(NoteDbContext noteDbContext)
    {
        NoteDbContext = noteDbContext;
    }

    public async Task<TEntity?> GetByIdOrDefaultAsync(int id)
    {
        return await NoteDbContext.Set<TEntity>().FindAsync(id);
    }

    public async Task<IEnumerable<TEntity>> GetByExpressionAsync(Expression<Func<TEntity, bool>> expression)
    {
        return await NoteDbContext.Set<TEntity>().Where(expression).ToListAsync();
    }

    public void Update(TEntity entity)
    {
        NoteDbContext.Update(entity);
    }

    public void Add(TEntity entity)
    {
        NoteDbContext.Add(entity);
    }

    public void Remove(TEntity entity)
    {
        NoteDbContext.Remove(entity);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await NoteDbContext.Set<TEntity>().ToListAsync();
    }

    public async Task<PagedEntity<TEntity>> GetPagedEntityByExpressionAsync(Expression<Func<TEntity, bool>> expression, int skip, int take)
    {
        var query = NoteDbContext.Set<TEntity>().Where(expression);
        
        var total = await query.CountAsync();
        var entities = await query.Skip(skip).Take(take).ToArrayAsync();

        return new PagedEntity<TEntity>
        {
            Entities = entities,
            PageSize = take,
            Total = total
        };
    }
}