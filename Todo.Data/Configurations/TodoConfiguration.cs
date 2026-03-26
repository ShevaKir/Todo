using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Todo.Data.Configurations;

public class TodoConfiguration : IEntityTypeConfiguration<Domain.Entities.Todo>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Todo> builder)
    {
        builder.HasKey(t => t.Id);
        
        builder.Property(t => t.Title)
            .IsRequired()
            .HasMaxLength(200);
        
        builder.Property(t => t.Description)
            .HasColumnType("text");
        
        builder.Property(t => t.Status)
            .HasConversion<string>()
            .HasMaxLength(50);
        
        builder.Property(t => t.CreatedAt)
            .HasDefaultValueSql("NOW()");
        
        
    }
}