using Domain.Models.Evaluations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations.Evaluations
{
    public class EvaluationPeriodEvaluationConfiguration : IEntityTypeConfiguration<EvaluationPeriodEvaluation>
    {
        public void Configure(EntityTypeBuilder<EvaluationPeriodEvaluation> builder)
        {
            builder.ToTable("evaluation_period_evaluations", "dbo");

            builder.HasKey(epe => epe.Id);

            builder.HasOne(epe => epe.Evaluation)
                .WithMany(e => e.EvaluationPeriodEvaluations)
                .HasForeignKey(epe => epe.EvaluationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(epe => epe.EvaluationPeriod)
                .WithMany(ep => ep.EvaluationPeriodEvaluations)
                .HasForeignKey(epe => epe.EvaluationPeriodId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
