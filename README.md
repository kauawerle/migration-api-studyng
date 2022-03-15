# Como utilizar migrations

 - Utilizando o visual studio 19 baixe o Core Net 3.5
 - Vá para tools e em Gerenciador de pacotes Nugets
 - Baixe Microsoft.EntityFrameworkCore.SqlServer na versão 3.1.5
 - Microsoft.EntityFrameworkCore.Tools na versão 3.5

- Depois de instalado crie uma pasta na raiz de seu projeto chamada Models com o arquivo Cliente.cs e um arquivo chamado AppDbContext com os respectivos codigos:

- Cliente.cs:

```
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

            [MaxLength(100)]
            public string Nome { get; set; }

        }
    }
```

- AppDbContext:

```
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Migration_Estudo1.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Pedido> PedidoClientes { get; set; }
    }
}
```

- Adicionando um arquivo Pedido.cs iremos colocar:

```
namespace Migration_Estudo1.Models
{
    [Table("Pedidos")]
    public class Pedido
    {
        [Key]
        public int PedidoId { get; set; }

        public string Item { get; set; }

        public int Quantidade { get; set; }

        public decimal Preco { get; set; }

        public DateTime Data { get; set; }

        public int ClienteId { get; set; }

        public virtual Cliente Cliente { get; set; }
    }
}
```

>Perceba que não foi colocado nenhu atributo de MaxLength ou tipamos qual tipo de variável seria, iremos alterar o codigo do AppDbContext para colocar essas mudanças:


```
protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Para definir como chave primária o PedidoId
            modelBuilder.Entity<Pedido>()
                .HasKey(p => p.PedidoId);

            //Para gerar um valor aleatório no PedidoId
            modelBuilder.Entity<Pedido>()
                .Property(p => p.PedidoId)
                  .ValueGeneratedOnAdd();
            
            //Definir o tamanho máximo do Item do pedido
            modelBuilder.Entity<Pedido>()
               .Property(p => p.Item)
                 .HasMaxLength(200);


            //Definir o tipo da variável Preco
            modelBuilder.Entity<Pedido>()
               .Property(p => p.Preco)
                 .HasColumnType("decimal(18,2)");

            //Definir um novo nome para a tabela e a tipagem da variavel
            modelBuilder.Entity<Pedido>()
               .Property(p => p.Data)
                 .HasColumnName("DataPedido")
                 .HasColumnType("datetime2");


            //um-para-muitos: Fazer o relacionamento nas tabelas
            modelBuilder.Entity<Cliente>()
                .HasMany(p => p.Pedidos)
                    .WithOne(c => c.Cliente)
                        .OnDelete(DeleteBehavior.Cascade);


        }
```

- Cliente.cs:

```
public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }

        public string Nome { get; set; }

        public ICollection<Pedido> Pedidos { get; set; }

    }
```