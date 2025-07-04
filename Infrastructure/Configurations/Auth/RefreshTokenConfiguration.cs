using Domain.Models.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations.Auth
{
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.ToTable("refresh_tokens", "dbo");

            builder.HasKey(rt => rt.Id);

            builder.Property(rt => rt.Token)
                .HasMaxLength(256)
                .IsRequired();

            builder.HasIndex(rt => rt.Token)
                .IsUnique();

            builder.Property(rt => rt.ExpiryDate)
                .HasColumnType("datetime2")
                .IsRequired();

            builder.Property(rt => rt.IsRevoked)
                .IsRequired()
                .HasDefaultValue(false);

            builder.HasOne(rt => rt.User)
                .WithMany(u => u.RefreshTokens)
                .HasForeignKey(rt => rt.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(rt => rt.UserId);
        }
    }
}
