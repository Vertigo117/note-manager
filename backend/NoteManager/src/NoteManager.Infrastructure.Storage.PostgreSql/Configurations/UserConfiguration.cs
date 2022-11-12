using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NoteManager.Domain.Models.Entities;
using NoteManager.Domain.Models.Enums;

namespace NoteManager.Infrastructure.Storage.PostgreSql.Configurations;

internal class UserConfiguration : EntityConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);

        builder.Property(entity => entity.Email).IsRequired();
        builder.Property(entity => entity.Name).IsRequired();
        builder.Property(entity => entity.IsEmailVerified).IsRequired();
        builder.Property(entity => entity.PasswordHash).IsRequired();
        builder.Property(entity => entity.Role).HasConversion<EnumToStringConverter<AuthorizationRole>>().IsRequired();

        builder.HasMany(entity => entity.Notes).WithOne(entity => entity.User).HasForeignKey(entity => entity.UserId);
    }
}