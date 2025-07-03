using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations.Evaluations
{
    using Domain.Models;
    using Domain.Models.Evaluations;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ConcreteEvaluationConfiguration : IEntityTypeConfiguration<ConcreteEvaluation>
    {
        public void Configure(EntityTypeBuilder<ConcreteEvaluation> builder)
        {
            builder.ToTable("concrete_evaluations", "dbo");

            builder.HasKey(ce => ce.Id);

            builder.Property(ce => ce.SubmissionTimestamp)
                   .HasColumnName("SubmissionTime")
                   .HasColumnType("smalldatetime");

            builder.Property(ce => ce.Pending)
                   .HasColumnName("Pending")
                   .HasColumnType("tinyint")
                   .IsRequired()
                   .HasConversion(
                       v => (byte)(v ? 1 : 0),
                       v => v == 1
                   );

            // Delete behavior restrict means that if someone
            // tries to delete a user, it will stop him if
            // the user has been a reviewer or reviewee in the past
            builder.HasOne(ce => ce.Team)
                   .WithMany()
                   .HasForeignKey(ce => ce.TeamId)
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ce => ce.Evaluation)
                   .WithMany(e => e.ConcreteEvaluations)
                   .HasForeignKey(ce => ce.EvaluationId)
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ce => ce.Reviewer)
                   .WithMany()
                   .HasForeignKey(ce => ce.ReviewerId)
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ce => ce.Reviewee)
                   .WithMany()
                   .HasForeignKey(ce => ce.RevieweeId)
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ce => ce.EvaluationPeriod)
                    .WithMany(ep => ep.ConcreteEvaluations)
                    .HasForeignKey(ce => ce.EvaluationPeriodId)
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}