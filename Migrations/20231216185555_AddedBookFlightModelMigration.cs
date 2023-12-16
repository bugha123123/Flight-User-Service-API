using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookFlight.Migrations
{
    /// <inheritdoc />
    public partial class AddedBookFlightModelMigration : Migration
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

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "From", "Time", "To" },
                values: new object[,]
                {
                    { 1, "New York", "12:00 PM", "London" },
                    { 2, "Paris", "03:30 PM", "Tokyo" },
                    { 3, "New York", "01:55 AM", "Houston" },
                    { 4, "Los Angeles", "02:55 AM", "Phoenix" },
                    { 5, "Chicago", "03:55 AM", "Philadelphia" },
                    { 6, "Houston", "04:55 AM", "San Antonio" },
                    { 7, "Phoenix", "05:55 AM", "San Diego" },
                    { 8, "Philadelphia", "06:55 AM", "Dallas" },
                    { 9, "San Antonio", "07:55 AM", "San Jose" },
                    { 10, "San Diego", "08:55 AM", "Austin" },
                    { 11, "Dallas", "09:55 AM", "Jacksonville" },
                    { 12, "San Jose", "10:55 AM", "San Francisco" },
                    { 13, "Austin", "11:55 AM", "Indianapolis" },
                    { 14, "Jacksonville", "12:55 PM", "Columbus" },
                    { 15, "San Francisco", "01:55 PM", "Fort Worth" },
                    { 16, "Indianapolis", "02:55 PM", "Charlotte" },
                    { 17, "Columbus", "03:55 PM", "Seattle" },
                    { 18, "Fort Worth", "04:55 PM", "Denver" },
                    { 19, "Charlotte", "05:55 PM", "El Paso" },
                    { 20, "Seattle", "06:55 PM", "Detroit" },
                    { 21, "Denver", "07:55 PM", "Boston" },
                    { 22, "El Paso", "08:55 PM", "Memphis" },
                    { 23, "Detroit", "09:55 PM", "Nashville" },
                    { 24, "Boston", "10:55 PM", "Dubai" },
                    { 25, "Memphis", "11:55 PM", "New York" },
                    { 26, "Nashville", "12:55 AM", "Los Angeles" },
                    { 27, "Dubai", "01:55 AM", "Chicago" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flights");
        }
    }
}
