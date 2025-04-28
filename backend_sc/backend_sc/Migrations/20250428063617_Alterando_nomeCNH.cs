using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend_sc.Migrations
{
    /// <inheritdoc />
    public partial class Alterando_nomeCNH : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoriaCnhDesejada",
                table: "Alunos",
                newName: "CategoriaCnh");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoriaCnh",
                table: "Alunos",
                newName: "CategoriaCnhDesejada");
        }
    }
}
