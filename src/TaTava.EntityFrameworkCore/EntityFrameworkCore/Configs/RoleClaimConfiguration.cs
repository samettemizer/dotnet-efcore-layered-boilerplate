using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaTava.Authorization.RoleClaims;

namespace TaTava.EntityFrameworkCore.Configs
{
    public class RoleClaimConfiguration : EntityConfiguration<RoleClaim, Guid>
    {
        public override void Configure(EntityTypeBuilder<RoleClaim> builder)
        {
            builder.Property(roleClaim => roleClaim.RoleId)
                .HasColumnType("uniqueidentifier");

            builder.Property(roleClaim => roleClaim.PermissionName)
                .HasColumnType("nvarchar(255)")
                .HasMaxLength(255);

            base.Configure(builder);
        }
    }
}