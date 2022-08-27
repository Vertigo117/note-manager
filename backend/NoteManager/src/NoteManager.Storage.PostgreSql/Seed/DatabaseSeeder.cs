namespace NoteManager.Storage.PostgreSql.Seed;

/// <inheritdoc />
internal class DatabaseSeeder : IDatabaseSeeder
{
    private readonly NoteDbContext _noteDbContext;

    public DatabaseSeeder(NoteDbContext noteDbContext)
    {
        _noteDbContext = noteDbContext;
    }

    public void SeedData()
    {
        throw new NotImplementedException();
    }
}