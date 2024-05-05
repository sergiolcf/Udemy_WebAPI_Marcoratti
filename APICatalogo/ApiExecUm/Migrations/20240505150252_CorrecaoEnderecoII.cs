using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiExecUm.Migrations
{
    /// <inheritdoc />
    public partial class CorrecaoEnderecoII : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contas_Contatos_Endereco_ContatoId",
                table: "Contas");

            migrationBuilder.DropForeignKey(
                name: "FK_Contatos_Contas_Endereco_ContaId",
                table: "Contatos");

            migrationBuilder.DropIndex(
                name: "IX_Contatos_Endereco_ContaId",
                table: "Contatos");

            migrationBuilder.DropIndex(
                name: "IX_Contas_Endereco_ContatoId",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "Endereco_ContaId",
                table: "Contatos");

            migrationBuilder.DropColumn(
                name: "Endereco_ContatoId",
                table: "Contas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Endereco_ContaId",
                table: "Contatos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Endereco_ContatoId",
                table: "Contas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contatos_Endereco_ContaId",
                table: "Contatos",
                column: "Endereco_ContaId");

            migrationBuilder.CreateIndex(
                name: "IX_Contas_Endereco_ContatoId",
                table: "Contas",
                column: "Endereco_ContatoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contas_Contatos_Endereco_ContatoId",
                table: "Contas",
                column: "Endereco_ContatoId",
                principalTable: "Contatos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contatos_Contas_Endereco_ContaId",
                table: "Contatos",
                column: "Endereco_ContaId",
                principalTable: "Contas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
