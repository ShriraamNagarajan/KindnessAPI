using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KindnessAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddActTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Action = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Difficulty = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TimeRequired = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LocationType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImpactType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Acts",
                columns: new[] { "Id", "Action", "CreatedAt", "Difficulty", "ImpactType", "LocationType", "TimeRequired" },
                values: new object[,]
                {
                    { 1, "Hold the door open for someone", new DateTime(2024, 9, 15, 23, 21, 13, 51, DateTimeKind.Utc).AddTicks(9857), "Simple", "Personal", "Local", "Quick" },
                    { 2, "Donate to a local charity", new DateTime(2024, 9, 15, 23, 21, 13, 51, DateTimeKind.Utc).AddTicks(9860), "Moderate", "Community", "Local", "Medium" },
                    { 3, "Plant a tree", new DateTime(2024, 9, 15, 23, 21, 13, 51, DateTimeKind.Utc).AddTicks(9862), "Challenging", "Environmental", "Local", "Long" },
                    { 4, "Leave a positive review for a local business", new DateTime(2024, 9, 15, 23, 21, 13, 51, DateTimeKind.Utc).AddTicks(9864), "Simple", "Community", "Virtual", "Quick" },
                    { 5, "Send a thank you note to a friend", new DateTime(2024, 9, 15, 23, 21, 13, 51, DateTimeKind.Utc).AddTicks(9865), "Simple", "Personal", "Virtual", "Quick" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acts");
        }
    }
}
