using Microsoft.EntityFrameworkCore.Migrations;

namespace Migration_Estudo1.Migrations
{
    public partial class Empty : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {

            mb.Sql("INSERT INTO Cliente(Nome,Idade) VALUES('Maria', 22)");
            mb.Sql("INSERT INTO Cliente(Nome,Idade) VALUES('Pedro', 22)");

            mb.Sql("INSERT INTO Pedidos(Item,Quantidade,Preco,DataPedido,ClienteId) VALUES('Caderno',2,7.99,'2020-01-01',(SELECT ClienteId FROM Cliente Where Nome='Maria'))");
            mb.Sql("INSERT INTO Pedidos(Item,Quantidade,Preco,DataPedido,ClienteId) VALUES('Borracha',6,2.99,'2020-01-01',(SELECT ClienteId FROM Cliente Where Nome='Pedro'))");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Cliente");
            mb.Sql("DELETE FROM Pedido");
        }
    }
}
