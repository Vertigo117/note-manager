namespace NoteManager.Domain.Entities;

/// <summary>
/// Пользователь
/// </summary>
public class UserEntity : BaseEntity
{
    /// <summary>
    /// Email adress
    /// </summary>
    public string Email { get; set; } = default!;

    /// <summary>
    /// Имя
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// Захешированный пароль
    /// </summary>
    public string PasswordHash { get; set; } = default!;

    /// <summary>
    /// Навигационное свойство для связи с сущностью <see cref="NoteEntity"/>
    /// </summary>
    public IList<NoteEntity> Notes { get; set; } = default!;
}