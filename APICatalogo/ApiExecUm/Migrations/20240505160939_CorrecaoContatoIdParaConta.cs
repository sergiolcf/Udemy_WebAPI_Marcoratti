using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiExecUm.Migrations
{
    /// <inheritdoc />
    public partial class CorrecaoContatoIdParaConta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contas_Contatos_Contato",
                table: "Contas");

            migrationBuilder.RenameColumn(
                name: "Contato",
                table: "Contas",
                newName: "ContatoPrimarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Contas_Contato",
                table: "Contas",
                newName: "IX_Contas_ContatoPrimarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contas_Contatos_ContatoPrimarioId",
                table: "Contas",
                column: "ContatoPrimarioId",
                principalTable: "Contatos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contas_Contatos_ContatoPrimarioId",
                table: "Contas");

            migrationBuilder.RenameColumn(
                name: "ContatoPrimarioId",
                table: "Contas",
                newName: "Contato");

            migrationBuilder.RenameIndex(
                name: "IX_Contas_ContatoPrimarioId",
                table: "Contas",
                newName: "IX_Contas_Contato");

            migrationBuilder.AddForeignKey(
                name: "FK_Contas_Contatos_Contato",
                table: "Contas",
                column: "Contato",
                principalTable: "Contatos",
                principalColumn: "Id");
        }
    }
}
