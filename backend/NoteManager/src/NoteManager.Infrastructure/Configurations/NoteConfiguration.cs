using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoteManager.Domain.Models.Entities;

namespace NoteManager.Infrastructure.Configurations;

internal class NoteConfiguration : EntityConfiguration<Note>
{
    public override void Configure(EntityTypeBuilder<Note> builder)
    {
        base.Configure(builder);

        builder.Property(entity => entity.Title).IsRequired();
        builder.Property(entity => entity.Text);
        builder.Property(entity => entity.UserId).IsRequired();

        builder.HasOne(entity => entity.User).WithMany(entity => entity.Notes).HasForeignKey(entity => entity.UserId);
    }
}