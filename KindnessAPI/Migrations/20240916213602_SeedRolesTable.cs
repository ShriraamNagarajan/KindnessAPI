using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KindnessAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedRolesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Acts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 16, 21, 36, 1, 98, DateTimeKind.Utc).AddTicks(3417), new DateTime(2024, 9, 16, 21, 36, 1, 98, DateTimeKind.Utc).AddTicks(3418) });

            migrationBuilder.UpdateData(
                table: "Acts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 16, 21, 36, 1, 98, DateTimeKind.Utc).AddTicks(3422), new DateTime(2024, 9, 16, 21, 36, 1, 98, DateTimeKind.Utc).AddTicks(3423) });

            migrationBuilder.UpdateData(
                table: "Acts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 16, 21, 36, 1, 98, DateTimeKind.Utc).AddTicks(3426), new DateTime(2024, 9, 16, 21, 36, 1, 98, DateTimeKind.Utc).AddTicks(3426) });

            migrationBuilder.UpdateData(
                table: "Acts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 16, 21, 36, 1, 98, DateTimeKind.Utc).AddTicks(3429), new DateTime(2024, 9, 16, 21, 36, 1, 98, DateTimeKind.Utc).AddTicks(3429) });

            migrationBuilder.UpdateData(
                table: "Acts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 16, 21, 36, 1, 98, DateTimeKind.Utc).AddTicks(3432), new DateTime(2024, 9, 16, 21, 36, 1, 98, DateTimeKind.Utc).AddTicks(3432) });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3206214c-93fb-4b5a-8f8e-119f04ffa4b8", "3206214c-93fb-4b5a-8f8e-119f04ffa4b8", "Admin", "ADMIN" },
                    { "BC48D86B-C73B-4DF1-BDFF-02A85520BC1B", "BC48D86B-C73B-4DF1-BDFF-02A85520BC1B", "Customer", "CUSTOMER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3206214c-93fb-4b5a-8f8e-119f04ffa4b8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "BC48D86B-C73B-4DF1-BDFF-02A85520BC1B");

            migrationBuilder.UpdateData(
                table: "Acts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 16, 21, 14, 48, 736, DateTimeKind.Utc).AddTicks(6351), new DateTime(2024, 9, 16, 21, 14, 48, 736, DateTimeKind.Utc).AddTicks(6351) });

            migrationBuilder.UpdateData(
                table: "Acts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 16, 21, 14, 48, 736, DateTimeKind.Utc).AddTicks(6354), new DateTime(2024, 9, 16, 21, 14, 48, 736, DateTimeKind.Utc).AddTicks(6355) });

            migrationBuilder.UpdateData(
                table: "Acts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 16, 21, 14, 48, 736, DateTimeKind.Utc).AddTicks(6357), new DateTime(2024, 9, 16, 21, 14, 48, 736, DateTimeKind.Utc).AddTicks(6357) });

            migrationBuilder.UpdateData(
                table: "Acts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 16, 21, 14, 48, 736, DateTimeKind.Utc).AddTicks(6359), new DateTime(2024, 9, 16, 21, 14, 48, 736, DateTimeKind.Utc).AddTicks(6360) });

            migrationBuilder.UpdateData(
                table: "Acts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 16, 21, 14, 48, 736, DateTimeKind.Utc).AddTicks(6362), new DateTime(2024, 9, 16, 21, 14, 48, 736, DateTimeKind.Utc).AddTicks(6362) });
        }
    }
}
