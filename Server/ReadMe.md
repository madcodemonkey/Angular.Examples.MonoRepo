# EF Migration Tools
These are tools needed to run EF migrations.  Run the following command to see what you have installed
dotnet tool list --global

If you don't see a 6.x version, you should update your tools
Package Id      Version      Commands
--------------------------------------
dotnet-ef       6.0.6        dotnet-ef

Update your tools with this command:
dotnet tool update --global dotnet-ef --version 6.0.6

# EF Migrations
From the folder where the solution file is located run the following to create a migration:
dotnet ef migrations add SomeName -p Acme.Repositories -s Acme.Api --context AcmeContext

You can just run the project and EF migrations will update the database, but if you want to do it by hand run the following command
dotnet ef database update -p Acme.Repositories -s Acme.Api --context AcmeContext