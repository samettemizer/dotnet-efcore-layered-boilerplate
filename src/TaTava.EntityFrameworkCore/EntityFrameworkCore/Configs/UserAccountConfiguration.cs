using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaTava.Authorization.UserAccounts;

namespace TaTava.EntityFrameworkCore.Configs
{
    public class UserAccountConfiguration : EntityConfiguration<UserAccount, Guid>
    {
        public override void Configure(EntityTypeBuilder<UserAccount> builder)
        {
            builder.Property(userAccount => userAccount.Email)
                .HasColumnType("nvarchar(255)")
                .HasMaxLength(255);

            builder.Property(userAccount => userAccount.Password)
                .HasColumnType("nvarchar(999)")
                .HasMaxLength(999);

            base.Configure(builder);
        }
    }
}