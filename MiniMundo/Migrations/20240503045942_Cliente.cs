using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniMundo.Migrations
{
    /// <inheritdoc />
    public partial class Cliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeDoCliente",
                table: "Venda");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Venda",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProdutoId",
                table: "Venda",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Venda");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "Venda");

            migrationBuilder.AddColumn<string>(
                name: "NomeDoCliente",
                table: "Venda",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
