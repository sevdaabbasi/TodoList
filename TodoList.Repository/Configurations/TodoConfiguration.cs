using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoList.Models.Models;

namespace TodoList.Repository.Configurations;

public class TodoConfiguration : IEntityTypeConfiguration<Todo>
{
    public void Configure(EntityTypeBuilder<Todo> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Title).IsRequired()
            .HasMaxLength(200);
        builder.Property(t => t.Description).HasMaxLength(500);
        builder.Property(t => t.StartDate).IsRequired();
        builder.Property(t => t.EndDate).IsRequired();
        builder.Property(t => t.Completed).HasDefaultValue(false);
        builder.HasOne(t => t.Category).WithMany(c => c.Todos).HasForeignKey(t => t.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(t => t.User)
            .WithMany(u => u.Todos)
            .HasForeignKey(t => t.UserId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.Navigation(x => x.Category).AutoInclude();
        builder.Navigation(x => x.User).AutoInclude();
    }
}
