using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaTava.EntityFrameworkCore.Configs;
using TaTava.Menus;

namespace TaTava.EntityFrameworkCore.EntityFrameworkCore.Configs
{
    public class MenuConfiguration:EntityConfiguration<Menu,Guid>
    {
        public override void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.Property(menu => menu.Title)
                .HasColumnType("nVarchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(menu => menu.MenuOrder)
                .HasColumnType("tinyint")
                .IsRequired();

            builder.Property(menu => menu.Url)
                .HasColumnType("nvarchar(150)")
                .HasMaxLength(150)
                .IsRequired();
            
            builder.Property(menu => menu.IsActive)
                .HasColumnType("bit");

            base.Configure(builder);
        }
    }
}
