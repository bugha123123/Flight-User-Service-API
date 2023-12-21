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
                    { 3, "New York", "04:22 PM", "Houston" },
                    { 4, "Los Angeles", "05:22 PM", "Phoenix" },
                    { 5, "Chicago", "06:22 PM", "Philadelphia" },
                    { 6, "Houston", "07:22 PM", "San Antonio" },
                    { 7, "Phoenix", "08:22 PM", "San Diego" },
                    { 8, "Philadelphia", "09:22 PM", "Dallas" },
                    { 9, "San Antonio", "10:22 PM", "San Jose" },
                    { 10, "San Diego", "11:22 PM", "Austin" },
                    { 11, "Dallas", "12:22 AM", "Jacksonville" },
                    { 12, "San Jose", "01:22 AM", "San Francisco" },
                    { 13, "Austin", "02:22 AM", "Indianapolis" },
                    { 14, "Jacksonville", "03:22 AM", "Columbus" },
                    { 15, "San Francisco", "04:22 AM", "Fort Worth" },
                    { 16, "Indianapolis", "05:22 AM", "Charlotte" },
                    { 17, "Columbus", "06:22 AM", "Seattle" },
                    { 18, "Fort Worth", "07:22 AM", "Denver" },
                    { 19, "Charlotte", "08:22 AM", "El Paso" },
                    { 20, "Seattle", "09:22 AM", "Detroit" },
                    { 21, "Denver", "10:22 AM", "Boston" },
                    { 22, "El Paso", "11:22 AM", "Memphis" },
                    { 23, "Detroit", "12:22 PM", "Nashville" },
                    { 24, "Boston", "01:22 PM", "Dubai" },
                    { 25, "Memphis", "02:22 PM", "New York" },
                    { 26, "Nashville", "03:22 PM", "Los Angeles" },
                    { 27, "Dubai", "04:22 PM", "Chicago" }
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
