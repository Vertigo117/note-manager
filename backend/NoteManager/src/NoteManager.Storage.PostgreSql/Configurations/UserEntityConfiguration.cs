using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NoteManager.Domain.Models.Entities;
using NoteManager.Domain.Models.Enums;

namespace NoteManager.Storage.PostgreSql.Configurations;

internal class UserEntityConfiguration : BaseEntityConfiguration<UserEntity>
{
    public override void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        base.Configure(builder);

        builder.Property(entity => entity.Email).IsRequired();
        builder.Property(entity => entity.Name).IsRequired();
        builder.Property(entity => entity.EmailVerified).IsRequired();
        builder.Property(entity => entity.PasswordHash).IsRequired();
        builder.Property(entity => entity.Role).HasConversion<EnumToStringConverter<AuthorizationRole>>().IsRequired();

        builder.HasMany(entity => entity.Notes).WithOne(entity => entity.User).HasForeignKey(entity => entity.UserId);
    }
}