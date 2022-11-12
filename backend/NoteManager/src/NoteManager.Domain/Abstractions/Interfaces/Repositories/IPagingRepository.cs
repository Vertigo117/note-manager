using System.Linq.Expressions;
using NoteManager.Domain.Models;
using NoteManager.Domain.Models.Entities;

namespace NoteManager.Domain.Abstractions.Interfaces.Repositories;

/// <summary>
/// Репозиторий с поддержкой постраничного вывода сущностей
/// </summary>
/// <typeparam name="TEntity">Тип сущности</typeparam>
public interface IPagingRepository<TEntity> where TEntity : Entity
{
    /// <summary>
    /// Постраничное получение сущностей
    /// </summary>
    /// <param name="expression">Условие для фильтрации</param>
    /// <param name="take">Количество заметок на странице</param>
    /// <param name="skip">Сколько пропустить</param>
    /// <returns>Задачу, которая содержит модель постраничного вывода</returns>
    Task<EntityPage<TEntity>> GetEntityPageByExpressionAsync(
        Expression<Func<TEntity, bool>> expression,
        int skip,
        int take
    );
}