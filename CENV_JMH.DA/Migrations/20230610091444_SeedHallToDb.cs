using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CENV_JMH.DA.Migrations
{
    /// <inheritdoc />
    public partial class SeedHallToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Number_Hall",
                table: "Hall_Table",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Hall_Table",
                columns: new[] { "Hall_ID", "Max_Number_Places", "Name_Hall", "Number_Hall" },
                values: new object[,]
                {
                    { 1, 12, "The Avenue", 1 },
                    { 2, 123, "Atlantis", 2 },
                    { 3, 99, "Lotus Lakes", 3 },
                    { 4, 134, "The Arctic", 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hall_Table",
                keyColumn: "Hall_ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hall_Table",
                keyColumn: "Hall_ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hall_Table",
                keyColumn: "Hall_ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hall_Table",
                keyColumn: "Hall_ID",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "Number_Hall",
                table: "Hall_Table");
        }
    }
}
