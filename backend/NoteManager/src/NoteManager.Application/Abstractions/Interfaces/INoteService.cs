using NoteManager.Application.Contracts;

namespace NoteManager.Application.Abstractions.Interfaces;

/// <summary>
/// Сервис для работы с заметками
/// </summary>
public interface INoteService
{
    /// <summary>
    /// Асинхронно создаёт новую заметку для пользователя с указанным уникальным идентификатором
    /// </summary>
    /// <param name="note">Данные для создания заметки</param>
    /// <param name="userId">Уникальный идентификатор пользователя</param>
    /// <returns>Задача, которая содержит результат выполнения асинхронной операции. Результат операции представляет
    /// собой данные созданной заметки</returns>
    Task<NoteDto> CreateAsync(NoteUpsertDto note, Guid userId);

    /// <summary>
    /// Асинхронно осуществляет постраничный вывод заметок пользователя с указанным уникальным идентификатором
    /// </summary>
    /// <param name="userId">Уникальный идентификатор пользователя</param>
    /// <param name="skip">Количество заметок, которые необходимо пропустить</param>
    /// <param name="take">Количество заметок, которые необходимо вывести</param>
    /// <returns>Задача, которая содержит результат выполнения асинхронной операции. Результат операции
    /// представляет собой страницу с заметками</returns>
    Task<NotePageDto> GetAsync(Guid userId, int skip, int take);

    /// <summary>
    /// Асинхронно обновляет данные заметки с указанным уникальным идентификатором
    /// </summary>
    /// <param name="id">Уникальный идентификатор заметки</param>
    /// <param name="note">Данные для обновления заметки</param>
    /// <returns>Задача, которая содержит результат выполнения асинхронной операции</returns>
    Task UpdateAsync(Guid id, NoteUpsertDto note);

    /// <summary>
    /// Асинхронно удаляет заметку с указанным уникальным идентификатором
    /// </summary>
    /// <param name="id">Уникальный идентификатор заметки</param>
    /// <returns>Задача, которая содержит результат выполнения асинхронной операции</returns>
    Task DeleteAsync(Guid id);
}