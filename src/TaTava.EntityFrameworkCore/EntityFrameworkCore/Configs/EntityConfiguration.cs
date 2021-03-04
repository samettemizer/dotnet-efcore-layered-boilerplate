using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaTava.Entities;

namespace TaTava.EntityFrameworkCore.Configs
{
    public class EntityConfiguration<TEntity, TKey> : IEntityTypeConfiguration<TEntity> where TEntity : Entity<TKey>
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(entity => entity.Id);
        }
    }
}