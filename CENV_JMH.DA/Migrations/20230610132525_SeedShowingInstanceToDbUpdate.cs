using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CENV_JMH.DA.Migrations
{
    /// <inheritdoc />
    public partial class SeedShowingInstanceToDbUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Showing_X_Hall",
                keyColumn: "ReGex_ID",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Showing_X_Hall",
                keyColumn: "ReGex_ID",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Showing_X_Hall",
                keyColumn: "ReGex_ID",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2023, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Showing_X_Hall",
                keyColumn: "ReGex_ID",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2023, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Showing_X_Hall",
                keyColumn: "ReGex_ID",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2023, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Showing_X_Hall",
                keyColumn: "ReGex_ID",
                keyValue: 6,
                column: "Date",
                value: new DateTime(2023, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Showing_X_Hall",
                keyColumn: "ReGex_ID",
                keyValue: 1,
                column: "Date",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(168));

            migrationBuilder.UpdateData(
                table: "Showing_X_Hall",
                keyColumn: "ReGex_ID",
                keyValue: 2,
                column: "Date",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(77));

            migrationBuilder.UpdateData(
                table: "Showing_X_Hall",
                keyColumn: "ReGex_ID",
                keyValue: 3,
                column: "Date",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(48));

            migrationBuilder.UpdateData(
                table: "Showing_X_Hall",
                keyColumn: "ReGex_ID",
                keyValue: 4,
                column: "Date",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(15));

            migrationBuilder.UpdateData(
                table: "Showing_X_Hall",
                keyColumn: "ReGex_ID",
                keyValue: 5,
                column: "Date",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(8));

            migrationBuilder.UpdateData(
                table: "Showing_X_Hall",
                keyColumn: "ReGex_ID",
                keyValue: 6,
                column: "Date",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(5));
        }
    }
}
