using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School.API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sobrenome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Escolaridade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "DataNascimento", "Email", "Escolaridade", "Nome", "Sobrenome" },
                values: new object[] { 1, new DateTime(1997, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "is.oscar@example.com", 1, "Hytalo", "Pinheiro" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "DataNascimento", "Email", "Escolaridade", "Nome", "Sobrenome" },
                values: new object[] { 2, new DateTime(1962, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "maria.francisca@example.com", 1, "Maria", "Francisca" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
