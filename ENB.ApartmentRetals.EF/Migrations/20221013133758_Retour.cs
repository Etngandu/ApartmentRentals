using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ENB.ApartmentRentals.EF.Migrations
{
    public partial class Retour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Apartment_Buildings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Building_short_name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Building_full_name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Building_description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Building_address = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    Building_manager = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Building_phone = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Other_buiding_details = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartment_Buildings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gender_code = table.Column<int>(type: "int", nullable: false),
                    Guest_first_name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Guest_last_name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Date_of_birth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Other_guest_details = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityRole",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Apartment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Apartment_BuildingId = table.Column<int>(type: "int", nullable: false),
                    Ap_type = table.Column<int>(type: "int", nullable: false),
                    Ap_number = table.Column<int>(type: "int", maxLength: 150, nullable: false),
                    Bathroom_count = table.Column<int>(type: "int", nullable: false),
                    Bedroom_count = table.Column<int>(type: "int", nullable: false),
                    Room_count = table.Column<int>(type: "int", nullable: false),
                    Other_apartement_details = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Apartment_Apartment_Buildings_Apartment_BuildingId",
                        column: x => x.Apartment_BuildingId,
                        principalTable: "Apartment_Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Apartment_booking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Apartment_Id = table.Column<int>(type: "int", nullable: false),
                    ApartmentId = table.Column<int>(type: "int", nullable: true),
                    Guest_Id = table.Column<int>(type: "int", nullable: false),
                    GuestId = table.Column<int>(type: "int", nullable: true),
                    Booking_status_code = table.Column<int>(type: "int", nullable: false),
                    Booking_start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Booking_end_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Other_booking_details = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartment_booking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Apartment_booking_Apartment_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "Apartment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Apartment_booking_Guests_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Guests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Apartment_facility",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Apartement_id = table.Column<int>(type: "int", nullable: false),
                    ApartmentId = table.Column<int>(type: "int", nullable: true),
                    Facilitycode = table.Column<int>(type: "int", nullable: false),
                    Other_facility_details = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartment_facility", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Apartment_facility_Apartment_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "Apartment",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0eaea63d-ceea-4005-8477-a191c27c8d0c", "b60837db-3fa8-46c9-aa6c-79e424041f36", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c4004c70-99cf-4d19-b5db-2b0093441ddd", "2dee28c8-c2c7-4269-abb7-e0a1c6d38937", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.CreateIndex(
                name: "IX_Apartment_Apartment_BuildingId",
                table: "Apartment",
                column: "Apartment_BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartment_booking_ApartmentId",
                table: "Apartment_booking",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartment_booking_GuestId",
                table: "Apartment_booking",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartment_facility_ApartmentId",
                table: "Apartment_facility",
                column: "ApartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apartment_booking");

            migrationBuilder.DropTable(
                name: "Apartment_facility");

            migrationBuilder.DropTable(
                name: "IdentityRole");

            migrationBuilder.DropTable(
                name: "Guests");

            migrationBuilder.DropTable(
                name: "Apartment");

            migrationBuilder.DropTable(
                name: "Apartment_Buildings");
        }
    }
}
