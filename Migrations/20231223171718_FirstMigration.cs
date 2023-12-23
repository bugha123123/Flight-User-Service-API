using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookFlight.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    From = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    To = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TitleInput = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MyReviews = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationInput = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Search",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserSearched = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Search", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JoinedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "From", "Time", "To" },
                values: new object[,]
                {
                    { 1, "New York", "12:00 PM", "London" },
                    { 2, "Paris", "03:30 PM", "Tokyo" },
                    { 3, "New York", "12:17 AM", "Houston" },
                    { 4, "Los Angeles", "01:17 AM", "Phoenix" },
                    { 5, "Chicago", "02:17 AM", "Philadelphia" },
                    { 6, "Houston", "03:17 AM", "San Antonio" },
                    { 7, "Phoenix", "04:17 AM", "San Diego" },
                    { 8, "Philadelphia", "05:17 AM", "Dallas" },
                    { 9, "San Antonio", "06:17 AM", "San Jose" },
                    { 10, "San Diego", "07:17 AM", "Austin" },
                    { 11, "Dallas", "08:17 AM", "Jacksonville" },
                    { 12, "San Jose", "09:17 AM", "San Francisco" },
                    { 13, "Austin", "10:17 AM", "Indianapolis" },
                    { 14, "Jacksonville", "11:17 AM", "Columbus" },
                    { 15, "San Francisco", "12:17 PM", "Fort Worth" },
                    { 16, "Indianapolis", "01:17 PM", "Charlotte" },
                    { 17, "Columbus", "02:17 PM", "Seattle" },
                    { 18, "Fort Worth", "03:17 PM", "Denver" },
                    { 19, "Charlotte", "04:17 PM", "El Paso" },
                    { 20, "Seattle", "05:17 PM", "Detroit" },
                    { 21, "Denver", "06:17 PM", "Boston" },
                    { 22, "El Paso", "07:17 PM", "Memphis" },
                    { 23, "Detroit", "08:17 PM", "Nashville" },
                    { 24, "Boston", "09:17 PM", "Dubai" },
                    { 25, "Memphis", "10:17 PM", "New York" },
                    { 26, "Nashville", "11:17 PM", "Los Angeles" },
                    { 27, "Dubai", "12:17 AM", "Chicago" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Search");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
