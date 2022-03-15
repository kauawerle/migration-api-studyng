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

            modelBuilder.Entity<Cliente>()
                .HasKey(p => p.ClienteId);

            modelBuilder.Entity<Cliente>()
                .Property(p => p.ClienteId)
                  .ValueGeneratedOnAdd();

            modelBuilder.Entity<Cliente>()
               .Property(p => p.Nome)
                 .HasMaxLength(100)
                   .IsRequired();

            modelBuilder.Entity<Pedido>()
                .HasKey(p => p.PedidoId);

            modelBuilder.Entity<Pedido>()
                .Property(p => p.PedidoId)
                  .ValueGeneratedOnAdd();

            modelBuilder.Entity<Pedido>()
               .Property(p => p.Item)
                 .HasMaxLength(200)
                   .IsRequired();

            modelBuilder.Entity<Pedido>()
               .Property(p => p.Preco)
                 .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Pedido>()
               .Property(p => p.Data)
                 .HasColumnName("DataPedido")
                 .HasColumnType("datetime2");

            //um-para-muitos
            modelBuilder.Entity<Cliente>()
                .HasMany(p => p.Pedidos)
                    .WithOne(c => c.Cliente)
                        .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
