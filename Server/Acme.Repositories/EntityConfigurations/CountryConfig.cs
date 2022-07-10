using Acme.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Acme.Repositories.EntityConfigurations;

public class CountryConfig : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.ToTable("Country");
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id).IsRequired();
        builder.Property(t => t.Name).IsRequired();


        builder.HasData(new Country { Id = 1, Name = "United States" });
        builder.HasData(new Country { Id = 2, Name = "Canada" });

    }
}