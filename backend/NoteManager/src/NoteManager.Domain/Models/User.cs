using NoteManager.Domain.Enums;

namespace NoteManager.Domain.Models;

/// <summary>
/// Пользователь
/// </summary>
public class User : Entity
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
    /// Навигационное свойство для связи с сущностью <see cref="Note"/>
    /// </summary>
    public List<Note> Notes { get; set; } = new();
}