using Acme.Models;
using Acme.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Todo.Repositories;

internal class SeedAcmeTablePerson
{
    public static async Task SeedDataAsync(AcmeContext context)
    {
        if (await context.People.AnyAsync()) return;


        context.People.Add(new Person { FirstName = "Robert", LastName = "Hope", Email = "bob.hope@gmail.com", DateOfBirth = new DateTime(1903, 5, 29),
            AddressLine1 = "2627 N Hollywood Way", City = "Burbank", StateId = 5, CountryId = 1, PostalCode = "91505" });

        context.People.Add(new Person { FirstName = "James", LastName = "Thompson", Email = "james.thompson@gmail.com", DateOfBirth = new DateTime(1976, 3, 20),
            AddressLine1 = "416 Sid Snyder Ave SW", City = "Olympia", StateId = 49, CountryId = 1, PostalCode = "98504" });

        context.People.Add(new Person { FirstName = "Tom", LastName = "Hanks", Email = "Tom.Hanks@gmail.com", DateOfBirth = new DateTime(1956, 7, 9),
            AddressLine1 = "416 Sid Snyder Ave SW", City = "Olympia", StateId = 49, CountryId = 1, PostalCode = "98504" });

        context.People.Add(new Person { FirstName = "Chris", LastName = "Hemsworth", Email = "Chris.Hemsworth@gmail.com", DateOfBirth = new DateTime(1983, 7, 11),
            AddressLine1 = "203 Thomas Street", City = "Fayetteville", StateId = 34, CountryId = 1, PostalCode = "28303" });
        
        context.People.Add(new Person { FirstName = "Leonardo", LastName = "DiCaprio", Email = "Leonardo.DiCaprio@gmail.com", DateOfBirth = new DateTime(1974, 11, 11),
            AddressLine1 = "416 Sid Snyder Ave SW", City = "Olympia", StateId = 49, CountryId = 1, PostalCode = "98504" });

        context.People.Add(new Person { FirstName = "Denzel", LastName = "Washington", Email = "Denzel.Washington@gmail.com", DateOfBirth = new DateTime(1976, 3, 20),
            AddressLine1 = "416 Sid Snyder Ave SW", City = "Olympia", StateId = 49, CountryId = 1, PostalCode = "98504" });

        context.People.Add(new Person { FirstName = "Dwayne", LastName = "Johnson", Email = "Dwayne.Johnson@gmail.com", DateOfBirth = new DateTime(1976, 3, 20),
            AddressLine1 = "416 Sid Snyder Ave SW", City = "Olympia", StateId = 49, CountryId = 1, PostalCode = "98504" });

        context.People.Add(new Person { FirstName = "Moran", LastName = "Freeman", Email = "Moran.Freeman@gmail.com", DateOfBirth = new DateTime(1976, 3, 20),
            AddressLine1 = "416 Sid Snyder Ave SW", City = "Olympia", StateId = 49, CountryId = 1, PostalCode = "98504" });

        context.People.Add(new Person { FirstName = "Jack", LastName = "Nicholson", Email = "Jack.Nicholson@gmail.com", DateOfBirth = new DateTime(1976, 3, 20),
            AddressLine1 = "416 Sid Snyder Ave SW", City = "Olympia", StateId = 49, CountryId = 1, PostalCode = "98504" });

        context.People.Add(new Person { FirstName = "Samuel", LastName = "Jackson", Email = "Samuel.Jackson@gmail.com", DateOfBirth = new DateTime(1976, 3, 20),
            AddressLine1 = "416 Sid Snyder Ave SW", City = "Olympia", StateId = 49, CountryId = 1, PostalCode = "98504" });

        context.People.Add(new Person { FirstName = "Harrison", LastName = "Ford", Email = "Harrison.Ford@gmail.com", DateOfBirth = new DateTime(1976, 3, 20),
            AddressLine1 = "416 Sid Snyder Ave SW", City = "Olympia", StateId = 49, CountryId = 1, PostalCode = "98504" });

        context.People.Add(new Person { FirstName = "Hugh", LastName = "Jackman", Email = "Hugh.Jackman@gmail.com", DateOfBirth = new DateTime(1976, 3, 20),
            AddressLine1 = "416 Sid Snyder Ave SW", City = "Olympia", StateId = 49, CountryId = 1, PostalCode = "98504" });

        await context.SaveChangesAsync();
    }
}