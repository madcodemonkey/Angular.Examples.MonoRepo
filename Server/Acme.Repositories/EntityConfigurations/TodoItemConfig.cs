using Acme.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
 

namespace Acme.Repositories.EntityConfigurations;

public class TodoItemConfig : IEntityTypeConfiguration<TodoItem>
{
    public void Configure(EntityTypeBuilder<TodoItem> builder)
    {
        builder.ToTable("TodoItem");
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id).IsRequired().HasDefaultValueSql("NEWID()");
        builder.Property(t => t.Title).IsRequired();
        builder.Property(t => t.Description).IsRequired();
        builder.Property(t => t.Status).IsRequired();
    }
}