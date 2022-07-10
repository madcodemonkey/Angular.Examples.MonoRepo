using Acme.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Acme.Repositories.EntityConfigurations;

public class PersonConfig : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("Person");
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id).IsRequired();
        builder.Property(t => t.FirstName).IsRequired();
        builder.Property(t => t.LastName).IsRequired();
        builder.Property(t => t.Email).IsRequired();
        builder.Property(t => t.DateOfBirth);
        builder.Property(t => t.AddressLine1);
        builder.Property(t => t.AddressLine2);
        builder.Property(t => t.City);
        builder.Property(t => t.StateId);
        builder.Property(t => t.PostalCode);

        builder.HasOne(o => o.State)
            .WithMany()
            .HasForeignKey(fk => fk.StateId);
    }
}