using System.Reflection;
using Microsoft.EntityFrameworkCore;
using NoteManager.Domain.Models.Entities;

namespace NoteManager.Infrastructure.Storage.PostgreSql;

/// <summary>
/// Контекст приложения
/// </summary>
internal class NoteManagerDbContext : DbContext
{
    public const string Schema = "note";

    /// <summary>
    /// Пользователи
    /// </summary>
    public DbSet<User> Users => Set<User>();

    /// <summary>
    /// Заметки
    /// </summary>
    public DbSet<Note> Notes => Set<Note>();

    public NoteManagerDbContext(DbContextOptions<NoteManagerDbContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema(Schema);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}