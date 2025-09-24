using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pedidos.Domain;

namespace Pedidos.Data.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente> // separa a configuracao da entidade Cliente em outra classe
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes"); // nome da tabela
            builder.HasKey(c => c.Id); // chave primaria
            builder.Property(c => c.Nome).HasColumnType("VARCHAR(80)").IsRequired(); // nome da coluna, tipo e obrigatoriedade
            builder.Property(c => c.Telefone).HasColumnType("CHAR(11)");
            builder.Property(c => c.CEP).HasColumnType("CHAR(8)").IsRequired();
            builder.Property(c => c.Estado).HasColumnType("CHAR(2)").IsRequired();
            builder.Property(c => c.Cidade).HasMaxLength(60).IsRequired();

            builder.HasIndex(i => i.Telefone).HasDatabaseName("idx_cliente_telefone"); // chave secundaria (índice) -  mais rapido para consultas
        }
    }
}
