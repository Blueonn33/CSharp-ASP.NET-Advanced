using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedCinemasAndProjections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "TicketPrice",
                table: "Projections",
                type: "decimal(9,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "Id", "IsDeleted", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("087287bc-c953-413d-a967-1d3b4ba9e691"), false, "45 Main Street, Plovdiv", "Plovdiv Grand Cinema" },
                    { new Guid("4e2bc84e-7882-4386-8a83-17ad369a73b1"), false, "123 Vitosha Boulevard, Sofia", "Sofia Cinema Center" },
                    { new Guid("8de701c1-d8c5-401a-943c-15404f741b65"), false, "10 Sea Garden Avenue, Varna", "Varna Seaside Cinema" }
                });

            migrationBuilder.InsertData(
                table: "Projections",
                columns: new[] { "Id", "AvailableTickets", "CinemaId", "CinemaMovieId", "IsDeleted", "MovieId", "Showtime", "TicketPrice" },
                values: new object[,]
                {
                    { new Guid("a2f7e9c1-3d4b-4f6e-8a2c-1b5d9e7c3f8a"), 100, new Guid("4e2bc84e-7882-4386-8a83-17ad369a73b1"), null, false, new Guid("2f22c0dd-f7b9-46c3-a753-0d076dafb489"), new DateTime(2025, 1, 16, 20, 0, 0, 0, DateTimeKind.Unspecified), 13.50m },
                    { new Guid("a7b4c8d5-3f6e-4a7b-9c2d-1e8a5f3b7d9c"), 140, new Guid("8de701c1-d8c5-401a-943c-15404f741b65"), null, false, new Guid("4571bf2f-dbb3-446c-a92a-07cb77f47ed0"), new DateTime(2025, 1, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), 13.00m },
                    { new Guid("b4d9c6e2-1a8f-4b3e-6c7d-9e2f5a8b1c3d"), 110, new Guid("087287bc-c953-413d-a967-1d3b4ba9e691"), null, false, new Guid("eb13b5e6-b8fd-4e11-99ef-446e9e752558"), new DateTime(2025, 1, 15, 20, 30, 0, 0, DateTimeKind.Unspecified), 12.00m },
                    { new Guid("b8c5d9e6-4a7f-5b8c-0d3e-2f9a6c4b8e1a"), 125, new Guid("8de701c1-d8c5-401a-943c-15404f741b65"), null, false, new Guid("2f22c0dd-f7b9-46c3-a753-0d076dafb489"), new DateTime(2025, 1, 16, 18, 30, 0, 0, DateTimeKind.Unspecified), 14.00m },
                    { new Guid("c3e8b7a2-5f1d-4e9c-7b6a-8d3c2e9f4a1b"), 85, new Guid("4e2bc84e-7882-4386-8a83-17ad369a73b1"), null, false, new Guid("e673a37c-8ffc-46bf-a66d-18b8078d7c94"), new DateTime(2025, 1, 17, 18, 0, 0, 0, DateTimeKind.Unspecified), 11.50m },
                    { new Guid("c9d6e0f7-5b8f-6c9d-1e4f-3a0b7d5c9e2b"), 100, new Guid("8de701c1-d8c5-401a-943c-15404f741b65"), null, false, new Guid("eb13b5e6-b8fd-4e11-99ef-446e9e752558"), new DateTime(2025, 1, 17, 19, 30, 0, 0, DateTimeKind.Unspecified), 12.50m },
                    { new Guid("d1a5c8f3-2b1e-4a7c-9f8d-5e3b1c7a4d9e"), 120, new Guid("4e2bc84e-7882-4386-8a83-17ad369a73b1"), null, false, new Guid("4571bf2f-dbb3-446c-a92a-07cb77f47ed0"), new DateTime(2025, 1, 15, 19, 30, 0, 0, DateTimeKind.Unspecified), 12.50m },
                    { new Guid("e5f2a9d1-4c7b-4a8e-9d3f-2e6c8b1a5f7d"), 95, new Guid("087287bc-c953-413d-a967-1d3b4ba9e691"), null, false, new Guid("94e73f37-e260-4c6f-930b-8bd65c9c8a11"), new DateTime(2025, 1, 16, 19, 0, 0, 0, DateTimeKind.Unspecified), 11.00m },
                    { new Guid("f6a3b8c9-2e5d-4f1a-8c9b-7d4e6f3a2c1e"), 130, new Guid("087287bc-c953-413d-a967-1d3b4ba9e691"), null, false, new Guid("96fcb0c2-807e-4f7d-a28b-14ba6f9cb9b4"), new DateTime(2025, 1, 17, 21, 0, 0, 0, DateTimeKind.Unspecified), 12.50m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: new Guid("a2f7e9c1-3d4b-4f6e-8a2c-1b5d9e7c3f8a"));

            migrationBuilder.DeleteData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: new Guid("a7b4c8d5-3f6e-4a7b-9c2d-1e8a5f3b7d9c"));

            migrationBuilder.DeleteData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: new Guid("b4d9c6e2-1a8f-4b3e-6c7d-9e2f5a8b1c3d"));

            migrationBuilder.DeleteData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: new Guid("b8c5d9e6-4a7f-5b8c-0d3e-2f9a6c4b8e1a"));

            migrationBuilder.DeleteData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: new Guid("c3e8b7a2-5f1d-4e9c-7b6a-8d3c2e9f4a1b"));

            migrationBuilder.DeleteData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: new Guid("c9d6e0f7-5b8f-6c9d-1e4f-3a0b7d5c9e2b"));

            migrationBuilder.DeleteData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: new Guid("d1a5c8f3-2b1e-4a7c-9f8d-5e3b1c7a4d9e"));

            migrationBuilder.DeleteData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: new Guid("e5f2a9d1-4c7b-4a8e-9d3f-2e6c8b1a5f7d"));

            migrationBuilder.DeleteData(
                table: "Projections",
                keyColumn: "Id",
                keyValue: new Guid("f6a3b8c9-2e5d-4f1a-8c9b-7d4e6f3a2c1e"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("087287bc-c953-413d-a967-1d3b4ba9e691"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("4e2bc84e-7882-4386-8a83-17ad369a73b1"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("8de701c1-d8c5-401a-943c-15404f741b65"));

            migrationBuilder.AlterColumn<decimal>(
                name: "TicketPrice",
                table: "Projections",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(9,4)");
        }
    }
}
