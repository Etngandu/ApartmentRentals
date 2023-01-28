using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ENB.ApartmentRentals.EF.Migrations
{
    public partial class fixkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "18b42bce-8b45-4977-9dcb-817f61780ef6");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "e858445f-4bf5-4b85-a078-d66468f55e73");

            migrationBuilder.DropColumn(
                name: "Apartement_id",
                table: "Apartment_facility");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "104b6dd5-eb0d-4c02-8fde-0e5a27029f0b", "8f75dff9-ca5f-4106-86bb-5dea95b979f2", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "530439a2-0352-4870-aca9-f56f9c6d9465", "efb34b3e-ea97-40df-8e42-77ad0d27333b", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "104b6dd5-eb0d-4c02-8fde-0e5a27029f0b");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "530439a2-0352-4870-aca9-f56f9c6d9465");

            migrationBuilder.AddColumn<int>(
                name: "Apartement_id",
                table: "Apartment_facility",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "18b42bce-8b45-4977-9dcb-817f61780ef6", "29a9ac44-1d6e-4e78-902e-547ddda036b9", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e858445f-4bf5-4b85-a078-d66468f55e73", "82056399-c75f-4b01-88e5-221e1aa87ac9", "Administrator", "ADMINISTRATOR" });
        }
    }
}
