using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using TaTava.Content.PostsTags;
using TaTava.EntityFrameworkCore.Configs;

namespace TaTava.EntityFrameworkCore.EntityFrameworkCore.Configs
{
    public class PostTagConfiguration:EntityConfiguration<PostTag,Guid>
    {
        public override void Configure(EntityTypeBuilder<PostTag> builder)
        {
            builder.HasKey(key => new { key.PostId, key.TagId });

            builder.Property(postTag => postTag.PostId)
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            builder.Property(postTag => postTag.TagId)
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            builder.HasOne(p => p.Post)
                .WithMany(pt => pt.postTags)
                .HasForeignKey(fk => fk.PostId);

            builder.HasOne(t => t.Tag)
                .WithMany(pt => pt.postTags)
                .HasForeignKey(fk => fk.TagId);
            
            base.Configure(builder);
        }
    }
}