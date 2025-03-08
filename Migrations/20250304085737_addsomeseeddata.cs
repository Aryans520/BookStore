using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStore.Migrations
{
    /// <inheritdoc />
    public partial class addsomeseeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Price", "QuantityInStock" },
                values: new object[,]
                {
                    { 4, 320000m, 5 },
                    { 5, 320000m, 6 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ItemId", "Name" },
                values: new object[,]
                {
                    { 4, "کتاب «سرگذشت ندیمه» اثر مارگارت اتوود یک کتاب ضدآرمان‌شهری تخیلی است که برای اولین بار در سال ۱۹۸۵ منتشر شده است", 4, "سرگذشت ندیمه" },
                    { 5, "تس ماجرای دختری زیبا و معصوم است که از شهر کوچکشان به شهری بزرگتر می‌رود تا خانواده واقعیش را ببیند.", 5, "تس دوربرویل" }
                });

            migrationBuilder.InsertData(
                table: "CategoryToProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 6, 4 },
                    { 6, 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CategoryToProducts",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 6, 4 });

            migrationBuilder.DeleteData(
                table: "CategoryToProducts",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 6, 5 });

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
