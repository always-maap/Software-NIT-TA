using IAM.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IAM.Infrastructure.Persistence_PgSql.Configurations;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .ToTable("Users");

        builder
            .HasKey(u => u.Id);

        builder
            .Property(u => u.Id)
            .IsRequired();

        builder
            .Property(u => u.FirstName)
            .HasMaxLength(50);

        builder
            .Property(u => u.LastName)
            .HasMaxLength(50);
        
        builder
            .Property(u => u.Phone)
            .IsRequired()
            .HasMaxLength(20);

        builder
            .Property(u => u.IsVerified);
    }
}