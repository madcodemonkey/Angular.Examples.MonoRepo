using Acme.Models;
using Acme.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Todo.Repositories;

internal class SeedAcmeTablePerson
{
    public static async Task SeedDataAsync(AcmeContext context)
    {
        if (await context.People.AnyAsync()) return;


        context.People.Add(new Person
        {
            Id = 1,
            FirstName = "Robert",
            LastName = "Hope",
            Email = "bob.hope@gmail.com",
            DateOfBirth = new DateTime(1903, 5, 29),
            AddressLine1 = "2627 N Hollywood Way",
            City = "Burbank",
            StateId = 5,
            CountryId = 1,
            PostalCode = "91505"
        });

        context.People.Add(new Person
        {
            Id = 2,
            FirstName = "James",
            LastName = "Thompson",
            Email = "james.thompson@gmail.com",
            DateOfBirth = new DateTime(1976, 3, 20),
            AddressLine1 = "416 Sid Snyder Ave SW",
            City = "Olympia",
            StateId = 49,
            CountryId = 1,
            PostalCode = "98504"
        });
    }
}