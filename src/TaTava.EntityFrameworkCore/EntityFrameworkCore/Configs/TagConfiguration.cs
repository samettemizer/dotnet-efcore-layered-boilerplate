using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaTava.Content.Tags;
using TaTava.EntityFrameworkCore.Configs;

namespace TaTava.EntityFrameworkCore.EntityFrameworkCore.Configs
{
    public class TagConfiguration:EntityConfiguration<Tag,Guid>
    {
        public override void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.Property(t => t.Title)
                .HasColumnType("nvarchar(150)")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(t => t.Url)
                .HasColumnType("nvarchar(300)")
                .IsRequired();

            base.Configure(builder);
        }
    }
}
