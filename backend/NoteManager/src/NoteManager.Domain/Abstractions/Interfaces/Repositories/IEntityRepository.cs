using System.Linq.Expressions;
using NoteManager.Domain.Models.Entities;

namespace NoteManager.Domain.Abstractions.Interfaces.Repositories;

/// <summary>
/// Репозиторий для доступа к данным сущности
/// </summary>
/// <typeparam name="TEntity">Тип сущности</typeparam>
public interface IEntityRepository<TEntity> where TEntity : Entity
{
    /// <summary>
    /// Создаёт новый экземпляр сущности
    /// </summary>
    /// <param name="entity">Экземпляр сущности</param>
    void Add(TEntity entity);
    
    /// <summary>
    /// Асинхронно получает экземпляр сущности с указанным уникальным идентификатором
    /// </summary>
    /// <param name="id">Уникальный идентификатор</param>
    /// <returns>Задача, которая содержит результат выполнения асинхронной операции.
    /// Результат операции представляет собой экземпляр сущности типа <typeparamref name="TEntity"/>
    /// с указанным уникальным идентификатором либо null, если экземпляра с таким идентификатором
    /// не найдено</returns>
    ValueTask<TEntity?> FindAsync(Guid id);

    /// <summary>
    /// Асинхронно получает все экземпляры сущности, соответствующие условию
    /// </summary>
    /// <param name="expression">Условие для выборки</param>
    /// <returns>Задача, которая содержит результат выполнения асинхронной операции.
    /// Результат представляет собой массив элементов типа <typeparamref name="TEntity"/></returns>
    Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression);

    /// <summary>
    /// Асинхронно получает все экземпляры сущности
    /// </summary>
    /// <returns>Задача, которая содержит результат выполнения асинхронной операции. Результат представляет собой
    /// массив сущностей</returns>
    Task<TEntity[]> GetAllAsync();

    /// <summary>
    /// Асинхронно получает все экземпляры сущности, соответствующие условию
    /// </summary>
    /// <param name="expression">Условие</param>
    /// <returns>Задача, которая содержит результат выполнения асинхронной операции. Результат представляет собой
    /// массив сущностей
    /// </returns>
    Task<TEntity[]> GetByExpressionAsync(Expression<Func<TEntity, bool>> expression);

    /// <summary>
    /// Обновить экземпляр сущности
    /// </summary>
    /// <param name="entity">Экземпляр сущности</param>
    void Update(TEntity entity);

    /// <summary>
    /// Удалить экземпляр сущности
    /// </summary>
    /// <param name="entity">Экземпляр сущности</param>
    void Remove(TEntity entity);
}