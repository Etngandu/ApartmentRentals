using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ENB.ApartmentRentals.EF.Migrations
{
    public partial class phonemail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "14132870-f688-47ca-8929-6c5bd46d7f19");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "b3447971-3062-425a-9add-363593045b5d");

            migrationBuilder.AddColumn<string>(
                name: "EmailAddres",
                table: "Guests",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Guests",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "41511951-f0d7-4233-ab74-3dc97cc80e24", "00dfe236-4b76-4f4d-9b92-910446165e1f", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4e95e35b-d0b0-4337-a17d-2b8a9f5a625b", "0c6556a2-e2c1-4740-85c0-02e9bf183c30", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "41511951-f0d7-4233-ab74-3dc97cc80e24");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "4e95e35b-d0b0-4337-a17d-2b8a9f5a625b");

            migrationBuilder.DropColumn(
                name: "EmailAddres",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Guests");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "14132870-f688-47ca-8929-6c5bd46d7f19", "a77e998d-a10d-429b-b3f0-fe16f92fb04a", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b3447971-3062-425a-9add-363593045b5d", "0213b9ae-e5b1-4536-932a-4b6853c2260c", "Administrator", "ADMINISTRATOR" });
        }
    }
}
