using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api_Exec_2.Migrations
{
    /// <inheritdoc />
    public partial class CorrecaoMigrationInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Endereco_Bairro",
                table: "Contatos",
                type: "varchar(150)",
                maxLength: 150,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Endereco_CEP",
                table: "Contatos",
                type: "varchar(9)",
                maxLength: 9,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Endereco_Complemento",
                table: "Contatos",
                type: "varchar(150)",
                maxLength: 150,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Endereco_Logradouro",
                table: "Contatos",
                type: "varchar(150)",
                maxLength: 150,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Endereco_Numero",
                table: "Contatos",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Endereco_Bairro",
                table: "Contatos");

            migrationBuilder.DropColumn(
                name: "Endereco_CEP",
                table: "Contatos");

            migrationBuilder.DropColumn(
                name: "Endereco_Complemento",
                table: "Contatos");

            migrationBuilder.DropColumn(
                name: "Endereco_Logradouro",
                table: "Contatos");

            migrationBuilder.DropColumn(
                name: "Endereco_Numero",
                table: "Contatos");
        }
    }
}
