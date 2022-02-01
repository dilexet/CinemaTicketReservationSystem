using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaTicketReservationSystem.DAL.Migrations
{
    public partial class ChangeBookedOrderId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SessionSeats_BookedOrders_BookedOrderId",
                table: "SessionSeats");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("49223b60-80e5-49f9-8405-ecf0541a6701"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4c197b96-439a-44ab-99fe-b4bfb4981098"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f7201009-c2c1-4458-b3fa-b87da1a15c6a"));

            migrationBuilder.AlterColumn<Guid>(
                name: "BookedOrderId",
                table: "SessionSeats",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("412e01a0-0594-457d-b4b4-352185296e96"), "Admin" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("cf68051c-208f-4e68-a250-0320cb58ead3"), "Manager" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("5566be61-29eb-49b7-b8f4-fc31b5bf9681"), "User" });

            migrationBuilder.AddForeignKey(
                name: "FK_SessionSeats_BookedOrders_BookedOrderId",
                table: "SessionSeats",
                column: "BookedOrderId",
                principalTable: "BookedOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SessionSeats_BookedOrders_BookedOrderId",
                table: "SessionSeats");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("412e01a0-0594-457d-b4b4-352185296e96"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("5566be61-29eb-49b7-b8f4-fc31b5bf9681"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("cf68051c-208f-4e68-a250-0320cb58ead3"));

            migrationBuilder.AlterColumn<Guid>(
                name: "BookedOrderId",
                table: "SessionSeats",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("4c197b96-439a-44ab-99fe-b4bfb4981098"), "Admin" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("49223b60-80e5-49f9-8405-ecf0541a6701"), "Manager" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("f7201009-c2c1-4458-b3fa-b87da1a15c6a"), "User" });

            migrationBuilder.AddForeignKey(
                name: "FK_SessionSeats_BookedOrders_BookedOrderId",
                table: "SessionSeats",
                column: "BookedOrderId",
                principalTable: "BookedOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
