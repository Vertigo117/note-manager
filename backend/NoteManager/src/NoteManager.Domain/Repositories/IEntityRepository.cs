using System.Linq.Expressions;
using NoteManager.Domain.Models.Entities;

namespace NoteManager.Domain.Repositories;

/// <summary>
/// Репозиторий для доступа к данным сущности
/// </summary>
/// <typeparam name="TEntity">Тип сущности</typeparam>
public interface IEntityRepository<TEntity> where TEntity : BaseEntity
{
    /// <summary>
    /// Получить экземпляр сущности с указанным уникальным идентификатором
    /// </summary>
    /// <param name="id">Уникальный идентификатор</param>
    /// <returns>Задача, которая содержит результат выполнения асинхронной операции.
    /// Результат операции представляет собой экземпляр сущности типа <typeparamref name="TEntity"/>
    /// с указанным уникальным идентификатором либо null, если экземпляра с таким идентификатором
    /// не найдено</returns>
    Task<TEntity?> GetByIdOrDefaultAsync(int id);

    /// <summary>
    /// Получить все экземпляры сущности, соответствующие условию
    /// </summary>
    /// <param name="expression">Условие для выборки</param>
    /// <returns>Задача, которая содержит результат выполнения асинхронной операции.
    /// Результат представляет собой коллекцию элементов типа <typeparamref name="TEntity"/></returns>
    Task<IEnumerable<TEntity>> GetByExpressionAsync(Expression<Func<TEntity, bool>> expression);

    /// <summary>
    /// Обновить экземпляр сущности
    /// </summary>
    /// <param name="entity">Экземпляр сущности</param>
    void Update(TEntity entity);

    /// <summary>
    /// Создать новый экземпляр сущности
    /// </summary>
    /// <param name="entity">Экземпляр сущности</param>
    void Add(TEntity entity);

    /// <summary>
    /// Удалить экземпляр сущности
    /// </summary>
    /// <param name="entity">Экземпляр сущности</param>
    void Remove(TEntity entity);

    /// <summary>
    /// Получить все экземпляры сущности
    /// </summary>
    /// <returns>Коллекция экземпляров сущности</returns>
    Task<IEnumerable<TEntity>> GetAllAsync();
}