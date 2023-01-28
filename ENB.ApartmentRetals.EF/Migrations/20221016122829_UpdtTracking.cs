using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ENB.ApartmentRentals.EF.Migrations
{
    public partial class UpdtTracking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "1a3ccc26-a991-4c7f-b58a-ae8557816e50");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "5ae7e6b9-525c-40c2-8bf0-4ee616558db8");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Guests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Guests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Apartment_facility",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Apartment_facility",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Apartment_Buildings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Apartment_Buildings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Apartment_BuildingId",
                table: "Apartment_booking",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Apartment_booking",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Apartment_booking",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Apartment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Apartment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cfe2599b-fdb1-4600-9a2f-66745ee366aa", "e239604e-0353-4ec5-9d3e-c7fdad471f9d", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fa280f1d-1530-4109-9c0d-247aea4d1568", "770ec15d-0ee0-4896-8e5b-11e61357a508", "Visitor", "VISITOR" });

            migrationBuilder.CreateIndex(
                name: "IX_Apartment_booking_Apartment_BuildingId",
                table: "Apartment_booking",
                column: "Apartment_BuildingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartment_booking_Apartment_Buildings_Apartment_BuildingId",
                table: "Apartment_booking",
                column: "Apartment_BuildingId",
                principalTable: "Apartment_Buildings",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartment_booking_Apartment_Buildings_Apartment_BuildingId",
                table: "Apartment_booking");

            migrationBuilder.DropIndex(
                name: "IX_Apartment_booking_Apartment_BuildingId",
                table: "Apartment_booking");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "cfe2599b-fdb1-4600-9a2f-66745ee366aa");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "fa280f1d-1530-4109-9c0d-247aea4d1568");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Apartment_facility");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Apartment_facility");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Apartment_Buildings");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Apartment_Buildings");

            migrationBuilder.DropColumn(
                name: "Apartment_BuildingId",
                table: "Apartment_booking");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Apartment_booking");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Apartment_booking");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Apartment");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Apartment");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1a3ccc26-a991-4c7f-b58a-ae8557816e50", "6d0eb524-b3e7-460d-aaf8-d135ee2c220e", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5ae7e6b9-525c-40c2-8bf0-4ee616558db8", "d9c82f5b-7575-429e-9f97-4a840375a23b", "Administrator", "ADMINISTRATOR" });
        }
    }
}
