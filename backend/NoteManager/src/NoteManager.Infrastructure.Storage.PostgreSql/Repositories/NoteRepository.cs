using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NoteManager.Domain.Abstractions.Interfaces.Repositories;
using NoteManager.Domain.Models;
using NoteManager.Domain.Models.Entities;

namespace NoteManager.Infrastructure.Storage.PostgreSql.Repositories;

/// <inheritdoc cref="INoteRepository"/>
internal class NoteEntityRepository : EntityRepository<Note>, INoteRepository
{
    public NoteEntityRepository(NoteManagerDbContext noteDbContext) : base(noteDbContext)
    { }

    public async Task<EntityPage<Note>> GetEntityPageAsync(int skip, int take)
    {
        var query = NoteDbContext.Set<Note>();

        var total = await query.CountAsync();
        var entities = await query.Skip(skip).Take(take).ToArrayAsync();

        return new EntityPage<Note>
        {
            Content = entities,
            ContentSize = take,
            Total = total
        };
    }

    public async Task<EntityPage<Note>> GetEntityPageByExpressionAsync(
        Expression<Func<Note, bool>> expression,
        int skip,
        int take
    )
    {
        var query = NoteDbContext.Set<Note>().Where(expression);

        var total = await query.CountAsync();
        var entities = await query.Skip(skip).Take(take).ToArrayAsync();

        return new EntityPage<Note>
        {
            Content = entities,
            ContentSize = take,
            Total = total
        };
    }
}