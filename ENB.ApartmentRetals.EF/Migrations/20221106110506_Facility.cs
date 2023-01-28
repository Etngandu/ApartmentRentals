using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ENB.ApartmentRentals.EF.Migrations
{
    public partial class Facility : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GuestAdress");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "41511951-f0d7-4233-ab74-3dc97cc80e24");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "4e95e35b-d0b0-4337-a17d-2b8a9f5a625b");

            migrationBuilder.AddColumn<int>(
                name: "Apartment_BuildingId",
                table: "Apartment_facility",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GuestAddress",
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
                    table.PrimaryKey("PK_GuestAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GuestAddress_Guests_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Guests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "18b42bce-8b45-4977-9dcb-817f61780ef6", "29a9ac44-1d6e-4e78-902e-547ddda036b9", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e858445f-4bf5-4b85-a078-d66468f55e73", "82056399-c75f-4b01-88e5-221e1aa87ac9", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.CreateIndex(
                name: "IX_Apartment_facility_Apartment_BuildingId",
                table: "Apartment_facility",
                column: "Apartment_BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_GuestAddress_GuestId",
                table: "GuestAddress",
                column: "GuestId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Apartment_facility_Apartment_Buildings_Apartment_BuildingId",
                table: "Apartment_facility",
                column: "Apartment_BuildingId",
                principalTable: "Apartment_Buildings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartment_facility_Apartment_Buildings_Apartment_BuildingId",
                table: "Apartment_facility");

            migrationBuilder.DropTable(
                name: "GuestAddress");

            migrationBuilder.DropIndex(
                name: "IX_Apartment_facility_Apartment_BuildingId",
                table: "Apartment_facility");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "18b42bce-8b45-4977-9dcb-817f61780ef6");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "e858445f-4bf5-4b85-a078-d66468f55e73");

            migrationBuilder.DropColumn(
                name: "Apartment_BuildingId",
                table: "Apartment_facility");

            migrationBuilder.CreateTable(
                name: "GuestAdress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuestId = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Number_street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State_province_county = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zipcode = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                values: new object[] { "41511951-f0d7-4233-ab74-3dc97cc80e24", "00dfe236-4b76-4f4d-9b92-910446165e1f", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4e95e35b-d0b0-4337-a17d-2b8a9f5a625b", "0c6556a2-e2c1-4740-85c0-02e9bf183c30", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.CreateIndex(
                name: "IX_GuestAdress_GuestId",
                table: "GuestAdress",
                column: "GuestId",
                unique: true);
        }
    }
}
