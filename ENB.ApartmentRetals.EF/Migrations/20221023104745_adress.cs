using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ENB.ApartmentRentals.EF.Migrations
{
    public partial class adress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "cfe2599b-fdb1-4600-9a2f-66745ee366aa");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "fa280f1d-1530-4109-9c0d-247aea4d1568");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Guests");

            migrationBuilder.CreateTable(
                name: "GuestAdress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number_street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zipcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State_province_county = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuestId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestAdress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GuestAdress_Guests_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Guests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "14132870-f688-47ca-8929-6c5bd46d7f19", "a77e998d-a10d-429b-b3f0-fe16f92fb04a", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b3447971-3062-425a-9add-363593045b5d", "0213b9ae-e5b1-4536-932a-4b6853c2260c", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.CreateIndex(
                name: "IX_GuestAdress_GuestId",
                table: "GuestAdress",
                column: "GuestId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GuestAdress");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "14132870-f688-47ca-8929-6c5bd46d7f19");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "b3447971-3062-425a-9add-363593045b5d");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Guests",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cfe2599b-fdb1-4600-9a2f-66745ee366aa", "e239604e-0353-4ec5-9d3e-c7fdad471f9d", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fa280f1d-1530-4109-9c0d-247aea4d1568", "770ec15d-0ee0-4896-8e5b-11e61357a508", "Visitor", "VISITOR" });
        }
    }
}
