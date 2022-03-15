using Microsoft.EntityFrameworkCore.Migrations;

namespace Migration_Estudo1.Migrations
{
    public partial class RelationalOneHasMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PrecoUnitario",
                table: "Pedidos",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Pedidos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ClienteId",
                table: "Pedidos",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Cliente_ClienteId",
                table: "Pedidos",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Cliente_ClienteId",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_ClienteId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Pedidos");

            migrationBuilder.AlterColumn<decimal>(
                name: "PrecoUnitario",
                table: "Pedidos",
                type: "decimal(18,2",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
