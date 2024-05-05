﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiExecUm.Migrations
{
    /// <inheritdoc />
    public partial class ContatoOpcional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contas_Contatos_Contato",
                table: "Contas");

            migrationBuilder.AlterColumn<int>(
                name: "Contato",
                table: "Contas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Contas_Contatos_Contato",
                table: "Contas",
                column: "Contato",
                principalTable: "Contatos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contas_Contatos_Contato",
                table: "Contas");

            migrationBuilder.AlterColumn<int>(
                name: "Contato",
                table: "Contas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contas_Contatos_Contato",
                table: "Contas",
                column: "Contato",
                principalTable: "Contatos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
