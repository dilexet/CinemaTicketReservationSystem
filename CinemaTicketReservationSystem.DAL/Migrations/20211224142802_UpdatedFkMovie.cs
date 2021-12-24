using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaTicketReservationSystem.DAL.Migrations
{
#pragma warning disable SA1601
    public partial class UpdatedFkMovie : Migration
#pragma warning restore SA1601
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieDescriptions_Movies_MovieId",
                table: "MovieDescriptions");

            migrationBuilder.DropIndex(
                name: "IX_MovieDescriptions_MovieId",
                table: "MovieDescriptions");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("0b09591c-40b3-4963-a4c5-32867af05ac2"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("63bcd85d-b01e-48f8-9ee5-772b0c39b260"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("dabdfc9a-49b7-4aa6-9a8f-507826800cf5"));

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "MovieDescriptions");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("f1cf0d29-4d6a-43bc-9c0e-9ab59cc2146c"), "Admin" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("0834c804-5f78-489a-8f4e-1033352e72ea"), "Manager" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("925c981b-67e0-4eb2-99b1-3d190d40bc50"), "User" });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_MovieDescriptionId",
                table: "Movies",
                column: "MovieDescriptionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_MovieDescriptions_MovieDescriptionId",
                table: "Movies",
                column: "MovieDescriptionId",
                principalTable: "MovieDescriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_MovieDescriptions_MovieDescriptionId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_MovieDescriptionId",
                table: "Movies");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("0834c804-5f78-489a-8f4e-1033352e72ea"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("925c981b-67e0-4eb2-99b1-3d190d40bc50"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f1cf0d29-4d6a-43bc-9c0e-9ab59cc2146c"));

            migrationBuilder.AddColumn<Guid>(
                name: "MovieId",
                table: "MovieDescriptions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("dabdfc9a-49b7-4aa6-9a8f-507826800cf5"), "Admin" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("0b09591c-40b3-4963-a4c5-32867af05ac2"), "Manager" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("63bcd85d-b01e-48f8-9ee5-772b0c39b260"), "User" });

            migrationBuilder.CreateIndex(
                name: "IX_MovieDescriptions_MovieId",
                table: "MovieDescriptions",
                column: "MovieId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieDescriptions_Movies_MovieId",
                table: "MovieDescriptions",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
