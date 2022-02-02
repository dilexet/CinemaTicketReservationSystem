using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaTicketReservationSystem.DAL.Migrations
{
    public partial class UpdateSessionEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("682cc1ab-575a-429d-9c63-7e68fd6afec3"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b177f1fa-9067-42bd-9c23-82e97366f103"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("cfb4db47-5530-4851-b183-5bf704e373c7"));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Sessions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("81a95f89-4347-4e1e-860e-cd63c0c799c9"), "Admin" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("05b7aee5-dea3-42f1-b10b-a17c4888c838"), "Manager" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("07c8cf55-4e89-446c-a941-05f496e4d730"), "User" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("05b7aee5-dea3-42f1-b10b-a17c4888c838"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("07c8cf55-4e89-446c-a941-05f496e4d730"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("81a95f89-4347-4e1e-860e-cd63c0c799c9"));

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Sessions");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("b177f1fa-9067-42bd-9c23-82e97366f103"), "Admin" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("cfb4db47-5530-4851-b183-5bf704e373c7"), "Manager" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("682cc1ab-575a-429d-9c63-7e68fd6afec3"), "User" });
        }
    }
}
