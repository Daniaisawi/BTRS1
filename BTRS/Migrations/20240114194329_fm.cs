using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTRS.Migrations
{
    public partial class fm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admin",
                columns: table => new
                {
                    AdminID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admin", x => x.AdminID);
                });

            migrationBuilder.CreateTable(
                name: "passengers",
                columns: table => new
                {
                    PassengerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_passengers", x => x.PassengerId);
                    table.ForeignKey(
                        name: "FK_passengers_admin_AdminID",
                        column: x => x.AdminID,
                        principalTable: "admin",
                        principalColumn: "AdminID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "trips",
                columns: table => new
                {
                    TripID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BusNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trips", x => x.TripID);
                    table.ForeignKey(
                        name: "FK_trips_admin_AdminID",
                        column: x => x.AdminID,
                        principalTable: "admin",
                        principalColumn: "AdminID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "booking",
                columns: table => new
                {
                    BookingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PassengerId = table.Column<int>(type: "int", nullable: false),
                    BusTripId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_booking", x => x.BookingID);
                    table.ForeignKey(
                        name: "FK_booking_passengers_PassengerId",
                        column: x => x.PassengerId,
                        principalTable: "passengers",
                        principalColumn: "PassengerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_booking_trips_BusTripId",
                        column: x => x.BusTripId,
                        principalTable: "trips",
                        principalColumn: "TripID"
                        
                        );
                });

            migrationBuilder.CreateTable(
                name: "buses",
                columns: table => new
                {
                    BusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaptainName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfSeats = table.Column<int>(type: "int", nullable: false),
                    BusTripId = table.Column<int>(type: "int", nullable: false),
                    AdminID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_buses", x => x.BusID);
                    table.ForeignKey(
                        name: "FK_buses_admin_AdminID",
                        column: x => x.AdminID,
                        principalTable: "admin",
                        principalColumn: "AdminID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_buses_trips_BusTripId",
                        column: x => x.BusTripId,
                        principalTable: "trips",
                        principalColumn: "TripID"
                       );
                });

            migrationBuilder.CreateIndex(
                name: "IX_booking_BusTripId",
                table: "booking",
                column: "BusTripId");

            migrationBuilder.CreateIndex(
                name: "IX_booking_PassengerId",
                table: "booking",
                column: "PassengerId");

            migrationBuilder.CreateIndex(
                name: "IX_buses_AdminID",
                table: "buses",
                column: "AdminID");

            migrationBuilder.CreateIndex(
                name: "IX_buses_BusTripId",
                table: "buses",
                column: "BusTripId");

            migrationBuilder.CreateIndex(
                name: "IX_passengers_AdminID",
                table: "passengers",
                column: "AdminID");

            migrationBuilder.CreateIndex(
                name: "IX_trips_AdminID",
                table: "trips",
                column: "AdminID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "booking");

            migrationBuilder.DropTable(
                name: "buses");

            migrationBuilder.DropTable(
                name: "passengers");

            migrationBuilder.DropTable(
                name: "trips");

            migrationBuilder.DropTable(
                name: "admin");
        }
    }
}
