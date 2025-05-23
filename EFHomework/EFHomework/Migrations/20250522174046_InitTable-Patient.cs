using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFHomework.Migrations
{
    /// <inheritdoc />
    public partial class InitTablePatient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "IdPatient", "Birthdate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateOnly(1985, 5, 15), "John", "Doe" },
                    { 2, new DateOnly(1990, 8, 22), "Jane", "Smith" },
                    { 3, new DateOnly(1975, 3, 10), "Michael", "Brown" },
                    { 4, new DateOnly(2000, 12, 5), "Emily", "Johnson" },
                    { 5, new DateOnly(1998, 7, 18), "David", "Lee" },
                    { 6, new DateOnly(1982, 1, 30), "Sophia", "Martinez" },
                    { 7, new DateOnly(1995, 4, 9), "Daniel", "Garcia" },
                    { 8, new DateOnly(1970, 9, 27), "Olivia", "Lopez" },
                    { 9, new DateOnly(1965, 6, 12), "William", "Wilson" },
                    { 10, new DateOnly(2002, 11, 2), "Emma", "Anderson" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 10);
        }
    }
}
