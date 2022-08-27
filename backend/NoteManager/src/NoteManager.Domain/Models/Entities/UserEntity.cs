using NoteManager.Domain.Models.Enums;

namespace NoteManager.Domain.Models.Entities;

/// <summary>
/// Пользователь
/// </summary>
public class UserEntity : BaseEntity
{
    /// <summary>
    /// Адрес электронной почты
    /// </summary>
    public string Email { get; set; } = null!;

    /// <summary>
    /// Флаг подтверждения электронной почты
    /// </summary>
    public bool EmailVerified { get; set; }

    /// <summary>
    /// Имя
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Роль пользователя в системе
    /// </summary>
    public AuthorizationRole Role { get; set; }

    /// <summary>
    /// Хеш пароля
    /// </summary>
    public string PasswordHash { get; set; } = null!;

    /// <summary>
    /// Навигационное свойство для связи с сущностью <see cref="NoteEntity"/>
    /// </summary>
    public List<NoteEntity> Notes { get; set; } = new();
}