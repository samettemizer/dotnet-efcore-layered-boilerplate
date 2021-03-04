using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaTava.Content.Posts;
using TaTava.EntityFrameworkCore.Configs;

namespace TaTava.EntityFrameworkCore.EntityFrameworkCore.Configs
{
    public class PostConfiguration : EntityConfiguration<Post, Guid>
    {
        public override void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property(p => p.Title)
                .HasColumnType("nvarchar(150)")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(p => p.Content)
                .HasColumnType("nvarchar(MAX)")
                .HasMaxLength(int.MaxValue)
                .IsRequired();

            builder.Property(p => p.PublishDate)
                .HasColumnType("datetime2");

            builder.Property(p => p.Published)
                .HasColumnType("bit")
                .IsRequired();

            builder.Property(p => p.QueueNumber)
                .HasColumnType("int");

            builder.Property(p => p.Url)
                .HasColumnType("nvarchar(300)")
                .IsRequired();

            builder.Property(p => p.AttachmentId)
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            base.Configure(builder);
        }
    }
}