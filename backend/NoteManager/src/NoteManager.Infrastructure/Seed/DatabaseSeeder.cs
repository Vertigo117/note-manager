namespace NoteManager.Infrastructure.Seed;

/// <inheritdoc />
internal class DatabaseSeeder : IDatabaseSeeder
{
    private readonly NoteManagerDbContext _noteDbContext;

    public DatabaseSeeder(NoteManagerDbContext noteDbContext)
    {
        _noteDbContext = noteDbContext;
    }

    public void SeedData()
    {
        throw new NotImplementedException();
    }
}