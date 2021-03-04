using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaTava.Authorization.Roles;

namespace TaTava.EntityFrameworkCore.Configs
{
    public class RoleConfiguration: EntityConfiguration<Role, Guid>
    {
        public override void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(role => role.RoleName)
                .HasColumnType("nvarchar(50)")
                .HasMaxLength(50)
                .IsRequired();

            base.Configure(builder);
        }
    }
}