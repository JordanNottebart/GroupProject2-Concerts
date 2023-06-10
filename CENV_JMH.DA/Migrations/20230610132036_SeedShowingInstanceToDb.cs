using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CENV_JMH.DA.Migrations
{
    /// <inheritdoc />
    public partial class SeedShowingInstanceToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Showing_X_Hall",
                columns: new[] { "ReGex_ID", "Date", "Hall_ID", "Number_of_Seats_Sold", "Showing_ID" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(168), 2, 1, 1 },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(77), 2, 2, 1 },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(48), 3, 123, 3 },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(15), 4, 272, 4 },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(8), 5, 165, 5 },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(5), 6, 66, 6 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Showing_X_Hall",
                keyColumn: "ReGex_ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Showing_X_Hall",
                keyColumn: "ReGex_ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Showing_X_Hall",
                keyColumn: "ReGex_ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Showing_X_Hall",
                keyColumn: "ReGex_ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Showing_X_Hall",
                keyColumn: "ReGex_ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Showing_X_Hall",
                keyColumn: "ReGex_ID",
                keyValue: 6);
        }
    }
}
