using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pedidos.Domain;

namespace Pedidos.Data.Configurations
{
    public class PedidoItemConfiguration : IEntityTypeConfiguration<PedidoItem> // separa a configuracao da entidade PedidoItem em outra classe
    {
        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            builder.ToTable("PedidoItens");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Quantidade).HasDefaultValue(1).IsRequired();
            builder.Property(p => p.Valor).IsRequired();
            builder.Property(p => p.Desconto).IsRequired();

            builder.HasOne(p => p.Pedido)
                .WithMany(p => p.Itens)
                .HasForeignKey(p => p.PedidoId); // relacionamento com Pedido
            builder.HasOne(p => p.Produto)
                .WithMany()
                .HasForeignKey(p => p.ProdutoId); // relacionamento com Produto
        }
    }
}