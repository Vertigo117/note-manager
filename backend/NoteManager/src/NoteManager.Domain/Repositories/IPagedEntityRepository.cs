using System.Linq.Expressions;
using NoteManager.Domain.Models.Entities;
using NoteManager.Domain.Models.Filters;

namespace NoteManager.Domain.Repositories;

/// <summary>
/// Репозиторий с поддержкой постраничного вывода сущностей
/// </summary>
/// <typeparam name="TEntity">Тип сущности</typeparam>
public interface IPagedEntityRepository<TEntity> where TEntity : BaseEntity
{
    /// <summary>
    /// Постраничное получение сущностей
    /// </summary>
    /// <param name="expression">Условие для фильтрации</param>
    /// <param name="take">Количество заметок на странице</param>
    /// <param name="skip">Сколько пропустить</param>
    /// <returns>Задачу, которая содержит модель постраничного вывода</returns>
    Task<PagedEntity<TEntity>> GetPagedEntityByExpressionAsync(
        Expression<Func<TEntity, bool>> expression,
        int skip,
        int take
    );
}