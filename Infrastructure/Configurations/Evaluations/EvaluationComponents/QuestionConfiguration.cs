using Domain.Models.Evaluations.EvaluationComponents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations.Evaluations.EvaluationComponents
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.ToTable("questions", "dbo");

            builder.HasKey(q => q.Id);

            builder.Property(q => q.Content)
                .HasColumnType("varchar(max)")
                .IsUnicode(false)
                .IsRequired();

            builder.Property(q => q.Type)
                .HasColumnType("tinyint")
                .IsRequired()
                .HasConversion<byte>();

            builder.Property(q => q.Category)
                .HasColumnName("Category")
                .HasColumnType("tinyint")
                .IsRequired()
                .HasConversion<byte>();

            builder.HasOne(q => q.Evaluation)
                .WithMany(e => e.Questions)
                .HasForeignKey(q => q.EvaluationId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
