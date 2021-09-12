using Microsoft.EntityFrameworkCore.Migrations;

namespace MassageSalon.DAL.EF.Migrations
{
    public partial class AddRecordsToEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Detail",
                table: "Records",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Records",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "VisitorId",
                table: "Records",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Records_VisitorId",
                table: "Records",
                column: "VisitorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Visitors_VisitorId",
                table: "Records",
                column: "VisitorId",
                principalTable: "Visitors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Records_Visitors_VisitorId",
                table: "Records");

            migrationBuilder.DropIndex(
                name: "IX_Records_VisitorId",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "Detail",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "VisitorId",
                table: "Records");
        }
    }
}
