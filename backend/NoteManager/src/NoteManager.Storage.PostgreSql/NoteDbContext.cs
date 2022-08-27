using System.Reflection;
using Microsoft.EntityFrameworkCore;
using NoteManager.Domain.Models.Entities;

namespace NoteManager.Storage.PostgreSql;

/// <summary>
/// Контекст приложения
/// </summary>
internal class NoteDbContext : DbContext
{
    public const string Schema = "note";

    /// <summary>
    /// Пользователи
    /// </summary>
    public DbSet<UserEntity> Users => Set<UserEntity>();

    /// <summary>
    /// Заметки
    /// </summary>
    public DbSet<NoteEntity> Notes => Set<NoteEntity>();

    public NoteDbContext(DbContextOptions<NoteDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema(Schema);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}