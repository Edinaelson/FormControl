using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormControl.Data.Migrations
{
    public partial class tipoFornecedor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TipoCliente",
                table: "Fornecedores",
                newName: "TipoFornecedor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TipoFornecedor",
                table: "Fornecedores",
                newName: "TipoCliente");
        }
    }
}
