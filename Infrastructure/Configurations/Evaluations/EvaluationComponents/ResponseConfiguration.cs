using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations.Evaluations.EvaluationComponents
{
    using Domain.Models.Evaluations.EvaluationComponents;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ResponseConfiguration : IEntityTypeConfiguration<Response>
    {
        public void Configure(EntityTypeBuilder<Response> builder)
        {
            builder.ToTable("responses", "dbo");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id).ValueGeneratedOnAdd();

            builder.Property(r => r.Type)
                   .HasColumnType("tinyint")
                   .IsRequired()
                   .HasConversion<byte>();

            builder.Property(r => r.Content)
                   .HasColumnType("varchar(max)")
                   .IsUnicode(false)
                   .IsRequired(false);


            builder.HasOne(r => r.Question)
                   .WithMany(q => q.Responses)
                   .HasForeignKey(r => r.QuestionId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.ConcreteEvaluation)
                   .WithMany(ce => ce.Responses)
                   .HasForeignKey(r => r.ConcreteEvaluationId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
