using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Consultar.Migrations
{
    public partial class MudandoPacienteEUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Pacientes_PacienteId",
                table: "Consultas");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.RenameColumn(
                name: "PacienteId",
                table: "Consultas",
                newName: "UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Consultas_PacienteId",
                table: "Consultas",
                newName: "IX_Consultas_UsuarioId");

            migrationBuilder.AddColumn<string>(
                name: "Celular",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Usuarios_UsuarioId",
                table: "Consultas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Usuarios_UsuarioId",
                table: "Consultas");

            migrationBuilder.DropColumn(
                name: "Celular",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Consultas",
                newName: "PacienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Consultas_UsuarioId",
                table: "Consultas",
                newName: "IX_Consultas_PacienteId");

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Pacientes_PacienteId",
                table: "Consultas",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
