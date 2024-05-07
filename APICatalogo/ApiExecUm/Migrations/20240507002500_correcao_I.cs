using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiExecUm.Migrations
{
    /// <inheritdoc />
    public partial class correcao_I : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Contatos",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);


            migrationBuilder.CreateIndex(
                name: "IX_Contas_ContatoPrimarioId",
                table: "Contas",
                column: "ContatoPrimarioId");

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


            migrationBuilder.DropIndex(
                name: "IX_Contas_ContatoPrimarioId",
                table: "Contas");



            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Contatos",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateIndex(
                name: "IX_Contatos_ContaID",
                table: "Contatos",
                column: "ContaID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contatos_Contas_Id",
                table: "Contatos",
                column: "Id",
                principalTable: "Contas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
