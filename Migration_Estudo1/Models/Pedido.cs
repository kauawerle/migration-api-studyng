using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Migration_Estudo1.Models
{
    [Table("Pedidos")]
    public class Pedido
    {
        [Key]
        public int PedidoId { get; set; }
        [MaxLength(200)]
        public string Item { get; set; }
        public int Quantidade { get; set; }

        //[Column("PrecoUnitario")]
        //public decimal Preco { get; set; }

        //[Column("DataPedido")]
        //public DateTime Data { get; set; }
    }
}
