using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiExecUm.Migrations
{
    /// <inheritdoc />
    public partial class correcaodacorrecao_II : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contas_Contatos_Contato",
                table: "Contas");

            migrationBuilder.DropIndex(
                name: "IX_Contas_Contato",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "Contato",
                table: "Contas");

            migrationBuilder.AddColumn<int>(
                name: "ContaID",
                table: "Contatos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contatos_ContaID",
                table: "Contatos",
                column: "ContaID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contatos_Contas_ContaID",
                table: "Contatos",
                column: "ContaID",
                principalTable: "Contas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contatos_Contas_ContaID",
                table: "Contatos");

            migrationBuilder.DropIndex(
                name: "IX_Contatos_ContaID",
                table: "Contatos");

            migrationBuilder.DropColumn(
                name: "ContaID",
                table: "Contatos");

            migrationBuilder.AddColumn<int>(
                name: "Contato",
                table: "Contas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contas_Contato",
                table: "Contas",
                column: "Contato");

            migrationBuilder.AddForeignKey(
                name: "FK_Contas_Contatos_Contato",
                table: "Contas",
                column: "Contato",
                principalTable: "Contatos",
                principalColumn: "Id");
        }
    }
}
