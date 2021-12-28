using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaTicketReservationSystem.DAL.Migrations
{
    public partial class AddedSeatType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7ef8ba6c-695b-4d1b-94b0-b53e3fa3c3dd"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8275929a-1da1-445b-8f4d-f01af2d7c040"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("86d4c36e-5bc0-41b8-86c8-8dec67fc47e4"));

            migrationBuilder.CreateTable(
                name: "SeatTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
#pragma warning disable SA1118 // Parameter should not span multiple lines
                values: new object[,]
                {
                    { new Guid("7ae29411-dcef-4b37-9782-04d63df7ceee"), "Admin" },
                    { new Guid("027cfedc-8faf-45b2-a253-f00348783217"), "Manager" },
                    { new Guid("82b2b7ca-238f-43e8-9ca1-6909ee903f92"), "User" }
                });
#pragma warning restore SA1118 // Parameter should not span multiple lines

            migrationBuilder.InsertData(
                table: "SeatTypes",
                columns: new[] { "Id", "Name" },
#pragma warning disable SA1118 // Parameter should not span multiple lines
                values: new object[,]
                {
                    { new Guid("21df568d-8f17-468c-b3d0-58c1b3050396"), "Love Seat" },
                    { new Guid("81211ef7-0852-4b96-89b2-65b55466ec37"), "Rest Sofa" },
                    { new Guid("dc8c83c9-b862-4e88-adee-5d035bae0d9a"), "Premiere Sofa" },
                    { new Guid("9a0b5e43-6055-4979-a8c9-f62357f8ed45"), "Private Suite" },
                    { new Guid("0dad8549-8abb-405b-98e2-dc1d2afa8d59"), "Bag Chair" },
                    { new Guid("ab438ddd-05b6-4a57-8c2f-1fbe61441dfc"), "VIP" },
                    { new Guid("248a4600-33fd-4fbc-a18f-e7f12d7b4837"), "Regular" }
                });
#pragma warning restore SA1118 // Parameter should not span multiple lines
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SeatTypes");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("027cfedc-8faf-45b2-a253-f00348783217"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7ae29411-dcef-4b37-9782-04d63df7ceee"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("82b2b7ca-238f-43e8-9ca1-6909ee903f92"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("86d4c36e-5bc0-41b8-86c8-8dec67fc47e4"), "Admin" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("8275929a-1da1-445b-8f4d-f01af2d7c040"), "Manager" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("7ef8ba6c-695b-4d1b-94b0-b53e3fa3c3dd"), "User" });
        }
    }
}
