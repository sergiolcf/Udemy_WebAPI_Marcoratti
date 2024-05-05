using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiExecUm.Migrations
{
    /// <inheritdoc />
    public partial class CorrecaoEndereco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contas_Enderecos_EnderecoId",
                table: "Contas");

            migrationBuilder.DropForeignKey(
                name: "FK_Contatos_Enderecos_EnderecoId",
                table: "Contatos");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropIndex(
                name: "IX_Contatos_EnderecoId",
                table: "Contatos");

            migrationBuilder.DropIndex(
                name: "IX_Contas_EnderecoId",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "Contatos");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "Contas");

            migrationBuilder.AddColumn<string>(
                name: "Endereco_Bairro",
                table: "Contatos",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Endereco_CEP",
                table: "Contatos",
                type: "varchar(14)",
                maxLength: 14,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Endereco_Complemento",
                table: "Contatos",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Endereco_ContaId",
                table: "Contatos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Endereco_Logradouro",
                table: "Contatos",
                type: "varchar(150)",
                maxLength: 150,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Endereco_Nome",
                table: "Contatos",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Endereco_Numero",
                table: "Contatos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Endereco_Bairro",
                table: "Contas",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Endereco_CEP",
                table: "Contas",
                type: "varchar(14)",
                maxLength: 14,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Endereco_Complemento",
                table: "Contas",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Endereco_ContatoId",
                table: "Contas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Endereco_Logradouro",
                table: "Contas",
                type: "varchar(150)",
                maxLength: 150,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Endereco_Nome",
                table: "Contas",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Endereco_Numero",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "Endereco_Bairro",
                table: "Contatos");

            migrationBuilder.DropColumn(
                name: "Endereco_CEP",
                table: "Contatos");

            migrationBuilder.DropColumn(
                name: "Endereco_Complemento",
                table: "Contatos");

            migrationBuilder.DropColumn(
                name: "Endereco_ContaId",
                table: "Contatos");

            migrationBuilder.DropColumn(
                name: "Endereco_Logradouro",
                table: "Contatos");

            migrationBuilder.DropColumn(
                name: "Endereco_Nome",
                table: "Contatos");

            migrationBuilder.DropColumn(
                name: "Endereco_Numero",
                table: "Contatos");

            migrationBuilder.DropColumn(
                name: "Endereco_Bairro",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "Endereco_CEP",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "Endereco_Complemento",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "Endereco_ContatoId",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "Endereco_Logradouro",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "Endereco_Nome",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "Endereco_Numero",
                table: "Contas");

            migrationBuilder.AddColumn<int>(
                name: "EnderecoId",
                table: "Contatos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EnderecoId",
                table: "Contas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Bairro = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CEP = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Complemento = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Logradouro = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nome = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Numero = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Contatos_EnderecoId",
                table: "Contatos",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Contas_EnderecoId",
                table: "Contas",
                column: "EnderecoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contas_Enderecos_EnderecoId",
                table: "Contas",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contatos_Enderecos_EnderecoId",
                table: "Contatos",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
