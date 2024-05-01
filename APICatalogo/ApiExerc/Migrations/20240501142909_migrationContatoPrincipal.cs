using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiExerc.Migrations
{
    /// <inheritdoc />
    public partial class migrationContatoPrincipal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contatos_Contas_ContaId",
                table: "Contatos");

            migrationBuilder.DropIndex(
                name: "IX_Contatos_ContaId",
                table: "Contatos");

            migrationBuilder.DropColumn(
                name: "ContaId",
                table: "Contatos");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Contatos",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "Contato_PrincipalId",
                table: "Contas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contas_Contato_PrincipalId",
                table: "Contas",
                column: "Contato_PrincipalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contas_Contatos_Contato_PrincipalId",
                table: "Contas",
                column: "Contato_PrincipalId",
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
                name: "FK_Contas_Contatos_Contato_PrincipalId",
                table: "Contas");

            migrationBuilder.DropForeignKey(
                name: "FK_Contatos_Contas_Id",
                table: "Contatos");

            migrationBuilder.DropIndex(
                name: "IX_Contas_Contato_PrincipalId",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "Contato_PrincipalId",
                table: "Contas");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Contatos",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "ContaId",
                table: "Contatos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contatos_ContaId",
                table: "Contatos",
                column: "ContaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contatos_Contas_ContaId",
                table: "Contatos",
                column: "ContaId",
                principalTable: "Contas",
                principalColumn: "Id");
        }
    }
}
