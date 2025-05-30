using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcunmedyaAkademiProject3.Migrations.ApplicationDb
{
    public partial class AddAdminProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminProfiles", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AdminProfiles",
                columns: new[] { "Id", "About", "Email", "FirstName", "LastName", "Phone", "ProfileImage", "UpdatedAt" },
                values: new object[] { 1, "Admin kullanıcısı", "admin@example.com", "Admin", "User", "", "default-profile.jpg", new DateTime(2025, 5, 30, 22, 50, 30, 170, DateTimeKind.Local).AddTicks(8716) });

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 30, 22, 50, 30, 170, DateTimeKind.Local).AddTicks(7671), "$2a$11$qzXyy8XI6IG9V0XSKPFmuOJLfTLD36Yg9R3d5ru0utvinFxRzJ6GC" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminProfiles");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2025, 5, 30, 22, 39, 43, 722, DateTimeKind.Local).AddTicks(4362), "$2a$11$.VJ0t0DM3kMZ0uulW/4Uf.GUt4Ol1Fn6nQuzrtsva6tsoCpxk/Wna" });
        }
    }
}
