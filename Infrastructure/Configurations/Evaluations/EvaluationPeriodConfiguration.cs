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
    public class EvaluationPeriodConfiguration : IEntityTypeConfiguration<EvaluationPeriod>
    {
        public void Configure(EntityTypeBuilder<EvaluationPeriod> builder)
        {
            builder.ToTable("evaluation_periods", "dbo");

            builder.HasKey(ep => ep.Id);

            builder.Property(ep => ep.StartDate)
                .HasColumnType("date");

            builder.Property(ep => ep.EndDate)
                .HasColumnType("date");

            builder.Property(ep => ep.Name)
                .HasMaxLength(30)
                .IsUnicode(false);

            builder.Property(ep => ep.Description)
                .HasColumnType("varchar(max)")
                .IsUnicode(false);
        }
    }
}
