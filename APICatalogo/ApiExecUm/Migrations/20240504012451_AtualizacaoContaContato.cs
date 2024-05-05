using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiExecUm.Migrations
{
    /// <inheritdoc />
    public partial class AtualizacaoContaContato : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "Contatos",
                type: "varchar(14)",
                maxLength: 14,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Contatos",
                type: "varchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "CNPJ",
                table: "Contas",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Contatos_CPF",
                table: "Contatos",
                column: "CPF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contas_CNPJ",
                table: "Contas",
                column: "CNPJ",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Contatos_CPF",
                table: "Contatos");

            migrationBuilder.DropIndex(
                name: "IX_Contas_CNPJ",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "CPF",
                table: "Contatos");

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Contatos");

            migrationBuilder.DropColumn(
                name: "CNPJ",
                table: "Contas");
        }
    }
}
