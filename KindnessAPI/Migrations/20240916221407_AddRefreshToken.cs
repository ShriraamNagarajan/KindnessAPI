using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KindnessAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddRefreshToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JwtTokenId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Refresh_Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsValid = table.Column<bool>(type: "bit", nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Acts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 16, 22, 14, 7, 111, DateTimeKind.Utc).AddTicks(6891), new DateTime(2024, 9, 16, 22, 14, 7, 111, DateTimeKind.Utc).AddTicks(6892) });

            migrationBuilder.UpdateData(
                table: "Acts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 16, 22, 14, 7, 111, DateTimeKind.Utc).AddTicks(6895), new DateTime(2024, 9, 16, 22, 14, 7, 111, DateTimeKind.Utc).AddTicks(6896) });

            migrationBuilder.UpdateData(
                table: "Acts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 16, 22, 14, 7, 111, DateTimeKind.Utc).AddTicks(6898), new DateTime(2024, 9, 16, 22, 14, 7, 111, DateTimeKind.Utc).AddTicks(6899) });

            migrationBuilder.UpdateData(
                table: "Acts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 16, 22, 14, 7, 111, DateTimeKind.Utc).AddTicks(6901), new DateTime(2024, 9, 16, 22, 14, 7, 111, DateTimeKind.Utc).AddTicks(6902) });

            migrationBuilder.UpdateData(
                table: "Acts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 16, 22, 14, 7, 111, DateTimeKind.Utc).AddTicks(6904), new DateTime(2024, 9, 16, 22, 14, 7, 111, DateTimeKind.Utc).AddTicks(6905) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshTokens");

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
        }
    }
}
