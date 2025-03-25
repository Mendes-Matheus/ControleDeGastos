using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleDeGastos.Migrations
{
    /// <inheritdoc />
    public partial class CriandoBancoDeDados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pessoa",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    Receitas = table.Column<double>(type: "float", nullable: false),
                    Despesas = table.Column<double>(type: "float", nullable: false),
                    Mesada = table.Column<double>(type: "float", nullable: false),
                    Saldo = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pessoa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transacao",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    DataHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoTransacao = table.Column<int>(type: "int", nullable: false),
                    PessoaId = table.Column<long>(type: "bigint", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Remetente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Destinatario = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transacao_pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transacao_PessoaId",
                table: "Transacao",
                column: "PessoaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transacao");

            migrationBuilder.DropTable(
                name: "pessoa");
        }
    }
}
