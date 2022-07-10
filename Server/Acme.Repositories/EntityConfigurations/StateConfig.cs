using Acme.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Acme.Repositories.EntityConfigurations;

public class StateConfig : IEntityTypeConfiguration<State>
{
    public void Configure(EntityTypeBuilder<State> builder)
    {
        builder.ToTable("State");
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id).IsRequired();
        builder.Property(t => t.Name).IsRequired();
        builder.Property(t => t.Abreviation).IsRequired();
        builder.Property(t => t.Description);

        builder.HasOne(o => o.Country)
            .WithMany(m => m.States);


        builder.HasData(new State { Id = 1, CountryId = 1, Name = "Alabama", Abreviation = "AL" });
        builder.HasData(new State { Id = 2, CountryId = 1, Name = "Alaska", Abreviation = "AK" });
        builder.HasData(new State { Id = 3, CountryId = 1, Name = "Arizona", Abreviation = "AZ" });
        builder.HasData(new State { Id = 4, CountryId = 1, Name = "Arkansas", Abreviation = "AR" });
        builder.HasData(new State { Id = 5, CountryId = 1, Name = "California", Abreviation = "CA" });
        builder.HasData(new State { Id = 6, CountryId = 1, Name = "Colorado", Abreviation = "CO" });
        builder.HasData(new State { Id = 7, CountryId = 1, Name = "Connecticut", Abreviation = "CT" });
        builder.HasData(new State { Id = 8, CountryId = 1, Name = "Delaware", Abreviation = "DE" });
        builder.HasData(new State { Id = 9, CountryId = 1, Name = "District of Columbia", Abreviation = "DC" });
        builder.HasData(new State { Id = 10, CountryId = 1, Name = "Florida", Abreviation = "FL" });
        builder.HasData(new State { Id = 11, CountryId = 1, Name = "Georgia", Abreviation = "GA" });
        builder.HasData(new State { Id = 12, CountryId = 1, Name = "Hawaii", Abreviation = "HI" });
        builder.HasData(new State { Id = 13, CountryId = 1, Name = "Idaho", Abreviation = "ID" });
        builder.HasData(new State { Id = 14, CountryId = 1, Name = "Illinois", Abreviation = "IL" });
        builder.HasData(new State { Id = 15, CountryId = 1, Name = "Indiana", Abreviation = "IN" });
        builder.HasData(new State { Id = 16, CountryId = 1, Name = "Iowa", Abreviation = "IA" });
        builder.HasData(new State { Id = 17, CountryId = 1, Name = "Kansas", Abreviation = "KS" });
        builder.HasData(new State { Id = 18, CountryId = 1, Name = "Kentucky", Abreviation = "KY" });
        builder.HasData(new State { Id = 19, CountryId = 1, Name = "Louisiana", Abreviation = "LA" });
        builder.HasData(new State { Id = 20, CountryId = 1, Name = "Maine", Abreviation = "ME" });
        builder.HasData(new State { Id = 21, CountryId = 1, Name = "Maryland", Abreviation = "MD" });
        builder.HasData(new State { Id = 22, CountryId = 1, Name = "Massachusetts", Abreviation = "MA" });
        builder.HasData(new State { Id = 23, CountryId = 1, Name = "Michigan", Abreviation = "MI" });
        builder.HasData(new State { Id = 24, CountryId = 1, Name = "Minnesota", Abreviation = "MN" });
        builder.HasData(new State { Id = 25, CountryId = 1, Name = "Mississippi", Abreviation = "MS" });
        builder.HasData(new State { Id = 26, CountryId = 1, Name = "Missouri", Abreviation = "MO" });
        builder.HasData(new State { Id = 27, CountryId = 1, Name = "Montana", Abreviation = "MT" });
        builder.HasData(new State { Id = 28, CountryId = 1, Name = "Nebraska", Abreviation = "NE" });
        builder.HasData(new State { Id = 29, CountryId = 1, Name = "Nevada", Abreviation = "NV" });
        builder.HasData(new State { Id = 30, CountryId = 1, Name = "New Hampshire", Abreviation = "NH" });
        builder.HasData(new State { Id = 31, CountryId = 1, Name = "New Jersey", Abreviation = "NJ" });
        builder.HasData(new State { Id = 32, CountryId = 1, Name = "New Mexico", Abreviation = "NM" });
        builder.HasData(new State { Id = 33, CountryId = 1, Name = "New York", Abreviation = "NY" });
        builder.HasData(new State { Id = 34, CountryId = 1, Name = "North Carolina", Abreviation = "NC" });
        builder.HasData(new State { Id = 35, CountryId = 1, Name = "North Dakota", Abreviation = "ND" });
        builder.HasData(new State { Id = 36, CountryId = 1, Name = "Ohio", Abreviation = "OH" });
        builder.HasData(new State { Id = 37, CountryId = 1, Name = "Oklahoma", Abreviation = "OK" });
        builder.HasData(new State { Id = 38, CountryId = 1, Name = "Oregon", Abreviation = "OR" });
        builder.HasData(new State { Id = 39, CountryId = 1, Name = "Pennsylvania", Abreviation = "PA" });
        builder.HasData(new State { Id = 40, CountryId = 1, Name = "Puerto Rico", Abreviation = "PR" });
        builder.HasData(new State { Id = 41, CountryId = 1, Name = "Rhode Island", Abreviation = "RI" });
        builder.HasData(new State { Id = 42, CountryId = 1, Name = "South Carolina", Abreviation = "SC" });
        builder.HasData(new State { Id = 43, CountryId = 1, Name = "South Dakota", Abreviation = "SD" });
        builder.HasData(new State { Id = 44, CountryId = 1, Name = "Tennessee", Abreviation = "TN" });
        builder.HasData(new State { Id = 45, CountryId = 1, Name = "Texas", Abreviation = "TX" });
        builder.HasData(new State { Id = 46, CountryId = 1, Name = "Utah", Abreviation = "UT" });
        builder.HasData(new State { Id = 47, CountryId = 1, Name = "Vermont", Abreviation = "VT" });
        builder.HasData(new State { Id = 48, CountryId = 1, Name = "Virginia", Abreviation = "VA" });
        builder.HasData(new State { Id = 49, CountryId = 1, Name = "Washington", Abreviation = "WA" });
        builder.HasData(new State { Id = 50, CountryId = 1, Name = "West Virginia", Abreviation = "WV" });
        builder.HasData(new State { Id = 51, CountryId = 1, Name = "Wisconsin", Abreviation = "WI" });
        builder.HasData(new State { Id = 52, CountryId = 1, Name = "Wyoming", Abreviation = "WY" });
        
        builder.HasData(new State { Id = 53, CountryId = 2, Name = "Alberta", Abreviation = "AB" });
        builder.HasData(new State { Id = 53, CountryId = 2, Name = "British Columbia", Abreviation = "BC" });
        builder.HasData(new State { Id = 53, CountryId = 2, Name = "Manitoba", Abreviation = "MB" });
        builder.HasData(new State { Id = 53, CountryId = 2, Name = "New Brunswick", Abreviation = "NB" });
        builder.HasData(new State { Id = 53, CountryId = 2, Name = "Newfoundland and Labrador", Abreviation = "NL" });
        builder.HasData(new State { Id = 53, CountryId = 2, Name = "Nova Scotia", Abreviation = "NS" });
        builder.HasData(new State { Id = 53, CountryId = 2, Name = "Ontario", Abreviation = "ON" });
        builder.HasData(new State { Id = 53, CountryId = 2, Name = "Prince Edward Island", Abreviation = "PE" });
        builder.HasData(new State { Id = 53, CountryId = 2, Name = "Quebec", Abreviation = "QC" });
        builder.HasData(new State { Id = 53, CountryId = 2, Name = "Saskatchewan", Abreviation = "SK" });
    }
}