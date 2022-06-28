namespace Acme.Models;

public class DatabaseOptions
{
    public bool RunMigrationsOnStartup { get; set; } = true;
    public string AcmeDbConnection { get; set; } = string.Empty;
}