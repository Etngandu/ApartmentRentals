using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ENB.ApartmentRentals.EF.Migrations
{
    public partial class correction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartment_booking_Apartment_ApartmentId",
                table: "Apartment_booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Apartment_booking_Guests_GuestId",
                table: "Apartment_booking");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "0eaea63d-ceea-4005-8477-a191c27c8d0c");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "c4004c70-99cf-4d19-b5db-2b0093441ddd");

            migrationBuilder.DropColumn(
                name: "Apartment_Id",
                table: "Apartment_booking");

            migrationBuilder.DropColumn(
                name: "Guest_Id",
                table: "Apartment_booking");

            migrationBuilder.AlterColumn<int>(
                name: "GuestId",
                table: "Apartment_booking",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ApartmentId",
                table: "Apartment_booking",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1a3ccc26-a991-4c7f-b58a-ae8557816e50", "6d0eb524-b3e7-460d-aaf8-d135ee2c220e", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5ae7e6b9-525c-40c2-8bf0-4ee616558db8", "d9c82f5b-7575-429e-9f97-4a840375a23b", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.AddForeignKey(
                name: "FK_Apartment_booking_Apartment_ApartmentId",
                table: "Apartment_booking",
                column: "ApartmentId",
                principalTable: "Apartment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Apartment_booking_Guests_GuestId",
                table: "Apartment_booking",
                column: "GuestId",
                principalTable: "Guests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartment_booking_Apartment_ApartmentId",
                table: "Apartment_booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Apartment_booking_Guests_GuestId",
                table: "Apartment_booking");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "1a3ccc26-a991-4c7f-b58a-ae8557816e50");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "5ae7e6b9-525c-40c2-8bf0-4ee616558db8");

            migrationBuilder.AlterColumn<int>(
                name: "GuestId",
                table: "Apartment_booking",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ApartmentId",
                table: "Apartment_booking",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Apartment_Id",
                table: "Apartment_booking",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Guest_Id",
                table: "Apartment_booking",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0eaea63d-ceea-4005-8477-a191c27c8d0c", "b60837db-3fa8-46c9-aa6c-79e424041f36", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c4004c70-99cf-4d19-b5db-2b0093441ddd", "2dee28c8-c2c7-4269-abb7-e0a1c6d38937", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.AddForeignKey(
                name: "FK_Apartment_booking_Apartment_ApartmentId",
                table: "Apartment_booking",
                column: "ApartmentId",
                principalTable: "Apartment",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartment_booking_Guests_GuestId",
                table: "Apartment_booking",
                column: "GuestId",
                principalTable: "Guests",
                principalColumn: "Id");
        }
    }
}
