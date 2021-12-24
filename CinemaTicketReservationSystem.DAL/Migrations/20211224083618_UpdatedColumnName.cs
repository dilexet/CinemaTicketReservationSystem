using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaTicketReservationSystem.DAL.Migrations
{
    public partial class UpdatedColumnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("e704bf06-8522-4c67-a880-cb66e58121ee"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f769d653-2bbf-4611-b969-3cbe459b7b39"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f7f79d9f-a7fa-48c6-bd6c-b7ff8d9520d7"));

            migrationBuilder.RenameColumn(
                name: "ScreenwritersString",
                table: "MovieDescriptions",
                newName: "Screenwriters");

            migrationBuilder.RenameColumn(
                name: "ProducersString",
                table: "MovieDescriptions",
                newName: "Producers");

            migrationBuilder.RenameColumn(
                name: "GenresString",
                table: "MovieDescriptions",
                newName: "Genres");

            migrationBuilder.RenameColumn(
                name: "DirectorsString",
                table: "MovieDescriptions",
                newName: "Directors");

            migrationBuilder.RenameColumn(
                name: "CountriesString",
                table: "MovieDescriptions",
                newName: "Countries");

            migrationBuilder.RenameColumn(
                name: "ActorsString",
                table: "MovieDescriptions",
                newName: "Actors");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.RenameColumn(
                name: "Screenwriters",
                table: "MovieDescriptions",
                newName: "ScreenwritersString");

            migrationBuilder.RenameColumn(
                name: "Producers",
                table: "MovieDescriptions",
                newName: "ProducersString");

            migrationBuilder.RenameColumn(
                name: "Genres",
                table: "MovieDescriptions",
                newName: "GenresString");

            migrationBuilder.RenameColumn(
                name: "Directors",
                table: "MovieDescriptions",
                newName: "DirectorsString");

            migrationBuilder.RenameColumn(
                name: "Countries",
                table: "MovieDescriptions",
                newName: "CountriesString");

            migrationBuilder.RenameColumn(
                name: "Actors",
                table: "MovieDescriptions",
                newName: "ActorsString");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("f7f79d9f-a7fa-48c6-bd6c-b7ff8d9520d7"), "Admin" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("e704bf06-8522-4c67-a880-cb66e58121ee"), "Manager" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("f769d653-2bbf-4611-b969-3cbe459b7b39"), "User" });
        }
    }
}
