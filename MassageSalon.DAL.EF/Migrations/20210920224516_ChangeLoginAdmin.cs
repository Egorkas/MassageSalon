using Microsoft.EntityFrameworkCore.Migrations;

namespace MassageSalon.DAL.EF.Migrations
{
    public partial class ChangeLoginAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Visitors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Login", "Password" },
                values: new object[] { "admin@gmail.com", "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Visitors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Login", "Password" },
                values: new object[] { "my@gmail.com", "123456" });
        }
    }
}
