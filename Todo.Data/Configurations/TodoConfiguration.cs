using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo.Domain.Entities;

namespace Todo.Data.Configurations;

public class TodoConfiguration : IEntityTypeConfiguration<TodoItem>
{
    public void Configure(EntityTypeBuilder<TodoItem> builder)
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