using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CENV_JMH.DA.Migrations
{
    /// <inheritdoc />
    public partial class SeedShowingToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Showing",
                columns: new[] { "Showing_ID", "Name_Showing", "Picture_URL", "Ticket_Price" },
                values: new object[,]
                {
                    { 1, "Mythical Music", "", 19.989999999999998 },
                    { 2, "The X Sounds", "", 199.99000000000001 },
                    { 3, "Dsss Trackk", "", 419.99000000000001 },
                    { 4, "Just A Voice", "", 219.99000000000001 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Showing",
                keyColumn: "Showing_ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Showing",
                keyColumn: "Showing_ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Showing",
                keyColumn: "Showing_ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Showing",
                keyColumn: "Showing_ID",
                keyValue: 4);
        }
    }
}
