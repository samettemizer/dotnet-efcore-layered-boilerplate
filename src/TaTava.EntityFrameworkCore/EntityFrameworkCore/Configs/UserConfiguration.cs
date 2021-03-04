using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaTava.Authorization.Users;

namespace TaTava.EntityFrameworkCore.Configs
{
    public class UserConfiguration : EntityConfiguration<User, Guid>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(user => user.FirstName)
                .HasColumnType("nvarchar(50)")
                .HasMaxLength(50)
                .IsRequired();


            builder.Property(user => user.LastName)
               .HasColumnType("nvarchar(50)")
               .HasMaxLength(50)
               .IsRequired();


            builder.Property(user => user.PhoneNumber)
                .HasColumnType("nvarchar(25)")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(user => user.Address)
                .HasColumnType("nvarchar(200)")
                .HasMaxLength(200)
                .IsRequired();

            base.Configure(builder);
        }
    }
}