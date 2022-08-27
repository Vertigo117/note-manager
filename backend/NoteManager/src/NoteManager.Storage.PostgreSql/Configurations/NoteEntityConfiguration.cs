using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoteManager.Domain.Models.Entities;

namespace NoteManager.Storage.PostgreSql.Configurations;

internal class NoteEntityConfiguration : BaseEntityConfiguration<NoteEntity>
{
    public override void Configure(EntityTypeBuilder<NoteEntity> builder)
    {
        base.Configure(builder);

        builder.Property(entity => entity.Name).IsRequired();
        builder.Property(entity => entity.Text).IsRequired(false);
        builder.Property(entity => entity.UserId).IsRequired();

        builder.HasOne(entity => entity.User).WithMany(entity => entity.Notes).HasForeignKey(entity => entity.UserId);
    }
}