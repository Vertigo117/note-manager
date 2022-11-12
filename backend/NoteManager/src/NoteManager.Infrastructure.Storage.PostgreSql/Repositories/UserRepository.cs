using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NoteManager.Domain.Abstractions.Interfaces.Repositories;
using NoteManager.Domain.Models.Entities;

namespace NoteManager.Infrastructure.Storage.PostgreSql.Repositories;

/// <inheritdoc cref="IUserRepository"/>
internal class UserRepository : EntityRepository<User>, IUserRepository
{
    public UserRepository(NoteManagerDbContext noteDbContext) : base(noteDbContext)
    { }

    public Task<User[]> GetByConditionWithIncludeAsync(
        Expression<Func<User, bool>> expression,
        params Expression<Func<User, object>>[] includeProperties
    )
    {
        var query = Include(includeProperties);

        return query.Where(expression).ToArrayAsync();
    }

    private IQueryable<User> Include(params Expression<Func<User, object>>[] includeProperties)
    {
        var query = NoteDbContext.Set<User>().AsNoTracking();

        return includeProperties.Aggregate(query, (entities, expression) => entities.Include(expression));
    }
}