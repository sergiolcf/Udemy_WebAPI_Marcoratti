using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiExecUm.Migrations
{
    /// <inheritdoc />
    public partial class correcaodacorrecao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contas_Contatos_ContatoPrimarioId",
                table: "Contas");

            migrationBuilder.DropForeignKey(
                name: "FK_Contatos_Contas_Id",
                table: "Contatos");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Contatos_Contas_Id",
                table: "Contatos",
                column: "Id",
                principalTable: "Contas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contas_Contatos_Contato",
                table: "Contas");

            migrationBuilder.DropForeignKey(
                name: "FK_Contatos_Contas_Id",
                table: "Contatos");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Contatos_Contas_Id",
                table: "Contatos",
                column: "Id",
                principalTable: "Contas",
                principalColumn: "Id");
        }
    }
}
