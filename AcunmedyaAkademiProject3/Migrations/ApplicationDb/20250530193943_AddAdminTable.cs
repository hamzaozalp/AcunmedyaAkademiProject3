using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcunmedyaAkademiProject3.Migrations.ApplicationDb
{
    public partial class AddAdminTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "CreatedAt", "IsActive", "Password", "Username" },
                values: new object[] { 1, new DateTime(2025, 5, 30, 22, 39, 43, 722, DateTimeKind.Local).AddTicks(4362), true, "$2a$11$.VJ0t0DM3kMZ0uulW/4Uf.GUt4Ol1Fn6nQuzrtsva6tsoCpxk/Wna", "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");
        }
    }
}
