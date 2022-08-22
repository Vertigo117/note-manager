namespace NoteManager.Domain.Entities;

/// <summary>
/// Пользователь
/// </summary>
public class UserEntity : BaseEntity
{
    /// <summary>
    /// Email adress
    /// </summary>
    public string Email { get; set; } = null!;

    /// <summary>
    /// Имя
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Захешированный пароль
    /// </summary>
    public string PasswordHash { get; set; } = null!;

    /// <summary>
    /// Навигационное свойство для связи с сущностью <see cref="NoteEntity"/>
    /// </summary>
    public List<NoteEntity> Notes { get; set; } = new();
}