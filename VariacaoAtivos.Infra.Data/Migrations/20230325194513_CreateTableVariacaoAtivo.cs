using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VariacaoAtivos.Infra.Data.Migrations
{
    public partial class CreateTableVariacaoAtivo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VARIACAOATIVO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ATIVO = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    DIA = table.Column<int>(type: "int", nullable: false),
                    DATA = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VALOR = table.Column<decimal>(type: "decimal(4,2)", nullable: true),
                    VARIACAODIA = table.Column<decimal>(type: "decimal(4,2)", nullable: true),
                    VARIACAOPRIMEIRADATA = table.Column<decimal>(type: "decimal(4,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VARIACAOATIVO", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VARIACAOATIVO");
        }
    }
}
