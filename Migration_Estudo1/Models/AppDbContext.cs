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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pedido>()
                .HasKey(p => p.PedidoId);

            modelBuilder.Entity<Pedido>()
                .Property(p => p.PedidoId)
                  .ValueGeneratedOnAdd();

            modelBuilder.Entity<Pedido>()
               .Property(p => p.Item)
                 .HasMaxLength(200);

            modelBuilder.Entity<Pedido>()
               .Property(p => p.Preco)
                 .HasColumnType("decimal(18,2");

            //modelBuilder.Entity<Pedido>()
            //   .Property(p => p.Data)
            //     .HasColumnName("DataPedido")
            //     .HasColumnType("datetime2");

        }
    }
}
