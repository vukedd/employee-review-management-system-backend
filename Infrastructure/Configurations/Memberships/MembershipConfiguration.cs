using Domain.Models.Memberships;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.Memberships
{
    public class MembershipConfiguration : IEntityTypeConfiguration<Membership>
    {
        public void Configure(EntityTypeBuilder<Membership> builder)
        {
            builder.ToTable("memberships", "dbo");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.IsTeamLead)
                   .HasColumnType("bit")
                   .IsRequired();

            // This block on the other hand defines the 1:* relationship,
            // between the user and the membership, where we define that
            // one membership can be related to one user, while a user can
            // be related to multiple memberships, specified the foreign
            // key inside of the membership class, and defined cascade deletion,
            // which means that when a user is deleted it will delete all
            // memberships which are related to himself.
            builder.HasOne(m => m.User)
                  .WithMany(u => u.Memberships)
                  .HasForeignKey(m => m.UserId)
                  .OnDelete(DeleteBehavior.Cascade);

            // Same as the previous one, just between teams and memberships
            builder.HasOne(m => m.Team)
                  .WithMany(t => t.Memberships)
                  .HasForeignKey(m => m.TeamId)
                  .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
