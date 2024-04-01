using IAM.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IAM.Infrastructure.Persistence.PgSql.Configurations;

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
            .ValueGeneratedOnAdd();
        
        builder
            .Property(u => u.FirstName)
            .IsRequired()
            .HasMaxLength(50);
        
        builder
            .Property(u => u.LastName)
            .IsRequired()
            .HasMaxLength(50);
        
        builder
            .Property(u => u.Phone)
            .IsRequired()
            .HasMaxLength(20);
        
        builder
            .Property(u => u.Password)
            .IsRequired()
            .HasMaxLength(100);
        
        builder
            .Property(u => u.IsVerified)
            .IsRequired();
    }
}