using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Acme.Repositories.Migrations
{
    public partial class NewTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Abreviation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                    table.ForeignKey(
                        name: "FK_State_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Person_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "United States" });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Canada" });

            migrationBuilder.InsertData(
                table: "State",
                columns: new[] { "Id", "Abreviation", "CountryId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "AL", 1, null, "Alabama" },
                    { 2, "AK", 1, null, "Alaska" },
                    { 3, "AZ", 1, null, "Arizona" },
                    { 4, "AR", 1, null, "Arkansas" },
                    { 5, "CA", 1, null, "California" },
                    { 6, "CO", 1, null, "Colorado" },
                    { 7, "CT", 1, null, "Connecticut" },
                    { 8, "DE", 1, null, "Delaware" },
                    { 9, "DC", 1, null, "District of Columbia" },
                    { 10, "FL", 1, null, "Florida" },
                    { 11, "GA", 1, null, "Georgia" },
                    { 12, "HI", 1, null, "Hawaii" },
                    { 13, "ID", 1, null, "Idaho" },
                    { 14, "IL", 1, null, "Illinois" },
                    { 15, "IN", 1, null, "Indiana" },
                    { 16, "IA", 1, null, "Iowa" },
                    { 17, "KS", 1, null, "Kansas" },
                    { 18, "KY", 1, null, "Kentucky" },
                    { 19, "LA", 1, null, "Louisiana" },
                    { 20, "ME", 1, null, "Maine" },
                    { 21, "MD", 1, null, "Maryland" },
                    { 22, "MA", 1, null, "Massachusetts" },
                    { 23, "MI", 1, null, "Michigan" },
                    { 24, "MN", 1, null, "Minnesota" },
                    { 25, "MS", 1, null, "Mississippi" },
                    { 26, "MO", 1, null, "Missouri" },
                    { 27, "MT", 1, null, "Montana" },
                    { 28, "NE", 1, null, "Nebraska" },
                    { 29, "NV", 1, null, "Nevada" },
                    { 30, "NH", 1, null, "New Hampshire" },
                    { 31, "NJ", 1, null, "New Jersey" },
                    { 32, "NM", 1, null, "New Mexico" },
                    { 33, "NY", 1, null, "New York" },
                    { 34, "NC", 1, null, "North Carolina" },
                    { 35, "ND", 1, null, "North Dakota" },
                    { 36, "OH", 1, null, "Ohio" },
                    { 37, "OK", 1, null, "Oklahoma" },
                    { 38, "OR", 1, null, "Oregon" },
                    { 39, "PA", 1, null, "Pennsylvania" },
                    { 40, "PR", 1, null, "Puerto Rico" },
                    { 41, "RI", 1, null, "Rhode Island" },
                    { 42, "SC", 1, null, "South Carolina" }
                });

            migrationBuilder.InsertData(
                table: "State",
                columns: new[] { "Id", "Abreviation", "CountryId", "Description", "Name" },
                values: new object[,]
                {
                    { 43, "SD", 1, null, "South Dakota" },
                    { 44, "TN", 1, null, "Tennessee" },
                    { 45, "TX", 1, null, "Texas" },
                    { 46, "UT", 1, null, "Utah" },
                    { 47, "VT", 1, null, "Vermont" },
                    { 48, "VA", 1, null, "Virginia" },
                    { 49, "WA", 1, null, "Washington" },
                    { 50, "WV", 1, null, "West Virginia" },
                    { 51, "WI", 1, null, "Wisconsin" },
                    { 52, "WY", 1, null, "Wyoming" },
                    { 53, "AB", 2, null, "Alberta" },
                    { 54, "BC", 2, null, "British Columbia" },
                    { 55, "MB", 2, null, "Manitoba" },
                    { 56, "NB", 2, null, "New Brunswick" },
                    { 57, "NL", 2, null, "Newfoundland and Labrador" },
                    { 58, "NS", 2, null, "Nova Scotia" },
                    { 59, "ON", 2, null, "Ontario" },
                    { 60, "PE", 2, null, "Prince Edward Island" },
                    { 61, "QC", 2, null, "Quebec" },
                    { 62, "SK", 2, null, "Saskatchewan" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Person_CountryId",
                table: "Person",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_StateId",
                table: "Person",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_State_CountryId",
                table: "State",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
