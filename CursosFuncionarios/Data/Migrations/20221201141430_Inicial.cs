using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CursosFuncionarios.Data.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    id_curso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    qtd_hora = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => x.id_curso);
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    id_funcionario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.id_funcionario);
                });

            migrationBuilder.CreateTable(
                name: "CursoAplicacao",
                columns: table => new
                {
                    id_curso_aplicacao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_curso = table.Column<int>(type: "int", nullable: false),
                    dt_inico = table.Column<DateTime>(type: "datetime2", nullable: true),
                    dt_fim = table.Column<DateTime>(type: "datetime2", nullable: true),
                    estado = table.Column<int>(type: "int", nullable: false),
                    tipo = table.Column<int>(type: "int", nullable: false),
                    CursoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursoAplicacao", x => x.id_curso_aplicacao);
                    table.ForeignKey(
                        name: "FK_CursoAplicacao_Curso_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Curso",
                        principalColumn: "id_curso");
                });

            migrationBuilder.CreateTable(
                name: "FuncionarioCurso",
                columns: table => new
                {
                    id_funcionario_curso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_funcionario = table.Column<int>(type: "int", nullable: false),
                    id_curso_aplicacao = table.Column<int>(type: "int", nullable: false),
                    observacao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    nota = table.Column<int>(type: "int", nullable: true),
                    Andamento = table.Column<int>(type: "int", nullable: false),
                    CursoAplicacaoId = table.Column<int>(type: "int", nullable: true),
                    FuncionarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuncionarioCurso", x => x.id_funcionario_curso);
                    table.ForeignKey(
                        name: "FK_FuncionarioCurso_CursoAplicacao_CursoAplicacaoId",
                        column: x => x.CursoAplicacaoId,
                        principalTable: "CursoAplicacao",
                        principalColumn: "id_curso_aplicacao");
                    table.ForeignKey(
                        name: "FK_FuncionarioCurso_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "id_funcionario");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CursoAplicacao_CursoId",
                table: "CursoAplicacao",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_FuncionarioCurso_CursoAplicacaoId",
                table: "FuncionarioCurso",
                column: "CursoAplicacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_FuncionarioCurso_FuncionarioId",
                table: "FuncionarioCurso",
                column: "FuncionarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FuncionarioCurso");

            migrationBuilder.DropTable(
                name: "CursoAplicacao");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "Curso");
        }
    }
}
