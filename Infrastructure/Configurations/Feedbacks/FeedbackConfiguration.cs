using Domain.Models;
using Domain.Models.Feedbacks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations.Feedbacks
{
    public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.ToTable("feedbacks", "dbo");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.Content)
                   .HasColumnType("varchar(max)")
                   .IsUnicode(false)
                   .IsRequired();

            builder.Property(f => f.Visibility)
                   .HasColumnType("tinyint")
                   .IsRequired()
                   .HasConversion<byte>();


            builder.HasOne(f => f.Reviewer)
                   .WithMany() 
                   .HasForeignKey(f => f.ReviewerId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(f => f.Reviewee)
                   .WithMany()
                   .HasForeignKey(f => f.RevieweeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(f => f.SubmissionTimestamp)
                .HasColumnType("datetime")
                .IsRequired();
        }
    }
}
