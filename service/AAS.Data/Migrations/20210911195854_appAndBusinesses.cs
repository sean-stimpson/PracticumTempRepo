using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AAS.Data.Migrations
{
    public partial class appAndBusinesses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    BusId = table.Column<int>(type: "int", nullable: false),
                    AppDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusId = table.Column<int>(type: "int", nullable: false),
                    SunOpen = table.Column<int>(type: "int", nullable: false),
                    SunClose = table.Column<int>(type: "int", nullable: false),
                    MonOpen = table.Column<int>(type: "int", nullable: false),
                    MonClose = table.Column<int>(type: "int", nullable: false),
                    TueOpen = table.Column<int>(type: "int", nullable: false),
                    TueClose = table.Column<int>(type: "int", nullable: false),
                    WedOpen = table.Column<int>(type: "int", nullable: false),
                    WedClose = table.Column<int>(type: "int", nullable: false),
                    ThuOpen = table.Column<int>(type: "int", nullable: false),
                    ThuClose = table.Column<int>(type: "int", nullable: false),
                    FriOpen = table.Column<int>(type: "int", nullable: false),
                    FriClose = table.Column<int>(type: "int", nullable: false),
                    SatOpen = table.Column<int>(type: "int", nullable: false),
                    SatClose = table.Column<int>(type: "int", nullable: false),
                    MinuteIncrement = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Schedules");
        }
    }
}
