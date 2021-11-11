using Microsoft.EntityFrameworkCore.Migrations;

namespace MassageSalon.DAL.EF.Migrations
{
    public partial class AddMasseursInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Masseurs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "TitleImagePath" },
                values: new object[] { "Masseur with 7 years of experience. Masseur of the 2020 year. Winner of the Masseur's championship 2018, 2020.", "Makar.jpg" });

            migrationBuilder.UpdateData(
                table: "Masseurs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name", "Surname", "TitleImagePath" },
                values: new object[] { "Masseur with 11 years of experience. He successfully ran the London College of Massage for many years. ", "Wendy", "Kavanagh", "Wendy.jpg" });

            migrationBuilder.UpdateData(
                table: "Masseurs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name", "TitleImagePath" },
                values: new object[] { "Masseur with 14 years of experience. Has Massage Assosiation Sertificate.", "Alex", "Alex.jpg" });

            migrationBuilder.InsertData(
                table: "Masseurs",
                columns: new[] { "Id", "Description", "FatherName", "Name", "Surname", "TitleImagePath" },
                values: new object[,]
                {
                    { 4, "Masseur with 23 years of experience. President and organizer of the European Massage Championship with the New Massage Association which will have its second edition in 2021.As an ex wellness therapist, and holding to the deep belief that massage presents a true benefit for the world, he dedicated the second part of of his massage career to the advancement of all massage techniques and especially, to make sure that the talent of massage therapists be recognized within the wellness community and more broadly with the general public. ", null, " Julien", "Elis", "Julias.jpg" },
                    { 5, "U.S. massage therapist won the gold medal in chair massage and a silver medal in overall best massage at the World Championship in Massage 2021 competition in Copenhagen, Denmark.", null, "Chaz", "Armstrong", "Chaz.jpg" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Masseurs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Masseurs",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Masseurs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "TitleImagePath" },
                values: new object[] { "The best masseur", "user_profile.jpg" });

            migrationBuilder.UpdateData(
                table: "Masseurs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name", "Surname", "TitleImagePath" },
                values: new object[] { "Good masseur", "Bega", "Dobrov", "user_profile.jpg" });

            migrationBuilder.UpdateData(
                table: "Masseurs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name", "TitleImagePath" },
                values: new object[] { "The best masseur", "Egor", "user_profile.jpg" });
        }
    }
}
