using Microsoft.EntityFrameworkCore.Migrations;

namespace Migration_Estudo1.Migrations
{
    public partial class IncluiIdadeCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Idade",
                table: "Cliente",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.Sql(@"CREATE PROCEDURE IdadeProcedure @Idade as Int AS SELECT * FROM Cliente Where Idade > @idade");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Idade",
                table: "Cliente");

            migrationBuilder.Sql(@"DROP PROCEDURE IdadeProcedure");
        }
    }
}
