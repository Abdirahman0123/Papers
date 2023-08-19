using Microsoft.EntityFrameworkCore.Migrations;

namespace Papers.Migrations
{
    public partial class seedate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Notepads", "A4 Refill Pad: 80 Sheets", 2m },
                    { 2, "Files & Folders", "Pukka Black Box File", 4m },
                    { 3, "Pens & Pencils", "5 Tier Gel Pen Case: Set of 60", 8m },
                    { 4, "Pens & Pencils", "Colouring Pencils: Pack of 15", 1m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
