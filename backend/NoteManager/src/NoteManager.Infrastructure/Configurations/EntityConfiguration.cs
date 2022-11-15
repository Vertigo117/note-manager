using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoteManager.Domain.Models.Entities;

namespace NoteManager.Infrastructure.Configurations;

internal abstract class EntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : Entity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Property(entity => entity.CreationDate).IsRequired().HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
    }
}