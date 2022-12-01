using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CursosFuncionarios.Data.Migrations
{
    public partial class LigacoesPaiFilhos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CursoAplicacao_Curso_CursoId",
                table: "CursoAplicacao");

            migrationBuilder.DropForeignKey(
                name: "FK_FuncionarioCurso_CursoAplicacao_CursoAplicacaoId",
                table: "FuncionarioCurso");

            migrationBuilder.DropForeignKey(
                name: "FK_FuncionarioCurso_Funcionario_FuncionarioId",
                table: "FuncionarioCurso");

            migrationBuilder.RenameColumn(
                name: "Andamento",
                table: "FuncionarioCurso",
                newName: "andamento");

            migrationBuilder.AlterColumn<int>(
                name: "FuncionarioId",
                table: "FuncionarioCurso",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CursoAplicacaoId",
                table: "FuncionarioCurso",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CursoId",
                table: "CursoAplicacao",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CursoAplicacao_Curso_CursoId",
                table: "CursoAplicacao",
                column: "CursoId",
                principalTable: "Curso",
                principalColumn: "id_curso",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FuncionarioCurso_CursoAplicacao_CursoAplicacaoId",
                table: "FuncionarioCurso",
                column: "CursoAplicacaoId",
                principalTable: "CursoAplicacao",
                principalColumn: "id_curso_aplicacao",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FuncionarioCurso_Funcionario_FuncionarioId",
                table: "FuncionarioCurso",
                column: "FuncionarioId",
                principalTable: "Funcionario",
                principalColumn: "id_funcionario",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CursoAplicacao_Curso_CursoId",
                table: "CursoAplicacao");

            migrationBuilder.DropForeignKey(
                name: "FK_FuncionarioCurso_CursoAplicacao_CursoAplicacaoId",
                table: "FuncionarioCurso");

            migrationBuilder.DropForeignKey(
                name: "FK_FuncionarioCurso_Funcionario_FuncionarioId",
                table: "FuncionarioCurso");

            migrationBuilder.RenameColumn(
                name: "andamento",
                table: "FuncionarioCurso",
                newName: "Andamento");

            migrationBuilder.AlterColumn<int>(
                name: "FuncionarioId",
                table: "FuncionarioCurso",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CursoAplicacaoId",
                table: "FuncionarioCurso",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CursoId",
                table: "CursoAplicacao",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_CursoAplicacao_Curso_CursoId",
                table: "CursoAplicacao",
                column: "CursoId",
                principalTable: "Curso",
                principalColumn: "id_curso");

            migrationBuilder.AddForeignKey(
                name: "FK_FuncionarioCurso_CursoAplicacao_CursoAplicacaoId",
                table: "FuncionarioCurso",
                column: "CursoAplicacaoId",
                principalTable: "CursoAplicacao",
                principalColumn: "id_curso_aplicacao");

            migrationBuilder.AddForeignKey(
                name: "FK_FuncionarioCurso_Funcionario_FuncionarioId",
                table: "FuncionarioCurso",
                column: "FuncionarioId",
                principalTable: "Funcionario",
                principalColumn: "id_funcionario");
        }
    }
}
