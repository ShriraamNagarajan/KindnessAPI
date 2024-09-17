using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KindnessAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateActTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Acts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Acts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 16, 1, 42, 34, 47, DateTimeKind.Utc).AddTicks(3459), new DateTime(2024, 9, 16, 1, 42, 34, 47, DateTimeKind.Utc).AddTicks(3460) });

            migrationBuilder.UpdateData(
                table: "Acts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 16, 1, 42, 34, 47, DateTimeKind.Utc).AddTicks(3462), new DateTime(2024, 9, 16, 1, 42, 34, 47, DateTimeKind.Utc).AddTicks(3463) });

            migrationBuilder.UpdateData(
                table: "Acts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 16, 1, 42, 34, 47, DateTimeKind.Utc).AddTicks(3465), new DateTime(2024, 9, 16, 1, 42, 34, 47, DateTimeKind.Utc).AddTicks(3465) });

            migrationBuilder.UpdateData(
                table: "Acts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 16, 1, 42, 34, 47, DateTimeKind.Utc).AddTicks(3467), new DateTime(2024, 9, 16, 1, 42, 34, 47, DateTimeKind.Utc).AddTicks(3467) });

            migrationBuilder.UpdateData(
                table: "Acts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 16, 1, 42, 34, 47, DateTimeKind.Utc).AddTicks(3469), new DateTime(2024, 9, 16, 1, 42, 34, 47, DateTimeKind.Utc).AddTicks(3470) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Acts");

            migrationBuilder.UpdateData(
                table: "Acts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 15, 23, 21, 13, 51, DateTimeKind.Utc).AddTicks(9857));

            migrationBuilder.UpdateData(
                table: "Acts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 15, 23, 21, 13, 51, DateTimeKind.Utc).AddTicks(9860));

            migrationBuilder.UpdateData(
                table: "Acts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 15, 23, 21, 13, 51, DateTimeKind.Utc).AddTicks(9862));

            migrationBuilder.UpdateData(
                table: "Acts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 15, 23, 21, 13, 51, DateTimeKind.Utc).AddTicks(9864));

            migrationBuilder.UpdateData(
                table: "Acts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 15, 23, 21, 13, 51, DateTimeKind.Utc).AddTicks(9865));
        }
    }
}
