namespace Acme.Models;

public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }
    public string City { get; set; }
    public int CountryId { get; set; }
    public int StateId { get; set; }
    public string PostalCode { get; set; }
    public Country Country { get; set; }
    public State State { get; set; }

}