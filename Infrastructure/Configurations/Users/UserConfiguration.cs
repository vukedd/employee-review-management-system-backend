namespace Infrastructure.Configurations.Users
{
    using Domain.Models.Users;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users", "dbo");
            builder.HasKey(u => u.Id);

            builder.HasIndex(u => u.Username).IsUnique();
            builder.HasIndex(u => u.Email).IsUnique();

            builder.Property(u => u.Username)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(u => u.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(u => u.FirstName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(u => u.LastName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(u => u.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .IsRequired();

            // This specifies that the role column in the database is of 
            // type tinyint which holds integer values from 0 to 255 and
            // also has a conversion type defined which means that every time
            // we want to write new user into the database it will convert the enum,
            // into a tinyint where the value will be it's ordinal, and when reading
            // from the database the ordinal will be converted into a enum literal,
            builder.Property(e => e.Role)
                .HasColumnType("tinyint")
                .IsRequired()
                .HasConversion<byte>();
        }
    }
}
