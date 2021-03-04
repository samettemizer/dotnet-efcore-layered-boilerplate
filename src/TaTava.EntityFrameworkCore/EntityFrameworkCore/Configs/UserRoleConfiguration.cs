using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaTava.Authorization.UserRoles;

namespace TaTava.EntityFrameworkCore.Configs
{
    public class UserRoleConfiguration : EntityConfiguration<UserRole, Guid>
    {
        public override void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(key => new { key.RoleId, key.UserId});

            builder.Property(userRole => userRole.RoleId)
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            builder.Property(userRole => userRole.UserId)
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            builder.HasOne(r => r.Role)
                .WithMany(ur => ur.UserRoles)
                .HasForeignKey(fk => fk.RoleId);

            builder.HasOne(u => u.User)
                .WithMany(ur => ur.UserRoles)
                .HasForeignKey(fk => fk.UserId);

            base.Configure(builder);
        }
    }
}