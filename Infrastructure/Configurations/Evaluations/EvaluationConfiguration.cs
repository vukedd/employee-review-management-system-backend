using Domain.Models;
using Domain.Models.Evaluations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations.Evaluations
{
    public class EvaluationConfiguration : IEntityTypeConfiguration<Evaluation>
    {
        public void Configure(EntityTypeBuilder<Evaluation> builder)
        {
            builder.ToTable("evaluations", "dbo");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Type)
                .HasColumnType("tinyint")
                .IsRequired()
                .HasConversion<byte>();
        }
    }
}
