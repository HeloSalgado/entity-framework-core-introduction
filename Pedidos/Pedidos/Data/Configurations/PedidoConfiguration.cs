using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pedidos.Domain;

namespace Pedidos.Data.Configurations
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido> // separa a configuracao da entidade Pedido em outra classe
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedidos");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.IniciadoEm).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd(); // valor padrao ao inserir
            builder.Property(p => p.FinalizadoEm).IsRequired(false); // pode ser nulo
            builder.Property(p => p.Status).HasConversion<string>();
            builder.Property(p => p.TipoFrete).HasConversion<int>();
            builder.Property(p => p.Observacao).HasColumnType("VARCHAR(512)");

            builder.HasOne(p => p.Cliente)
                .WithMany()
                .HasForeignKey(p => p.ClinteId); // relacionamento com Cliente
            builder.HasMany(p => p.Itens)
                .WithOne(i => i.Pedido)
                .OnDelete(DeleteBehavior.Cascade) // Se um Pedido for deletado, todos os seus Itens serão deletados junto (em cascata)
                .HasForeignKey(i => i.PedidoId); // relacionamento com PedidoItem
        }
    }
}