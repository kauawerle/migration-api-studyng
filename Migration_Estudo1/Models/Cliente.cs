using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Migration_Estudo1.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }

        public string Nome { get; set; }

        public int Idade { get; set; }

        public ICollection<Pedido> Pedidos { get; set; }

    }
}
