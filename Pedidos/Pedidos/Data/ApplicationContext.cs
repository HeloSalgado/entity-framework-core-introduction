using Microsoft.EntityFrameworkCore;
using Pedidos.Domain;

namespace Pedidos.Data
{
    public class ApplicationContext : DbContext // estabelece a conexao com o banco de dados
    {
        public DbSet<Pedido> Pedidos { get; set; } // representa a tabela no banco de dados
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // informar qual banco de dados (provider)
        {
            optionsBuilder.UseSqlServer("Server=SALGADO;Database=LojaDB;Trusted_Connection=True;"); // string de conexao
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // configurar as entidades (tabelas)
        {
            /* Esta única linha encontra e aplica TODAS as configurações
            que estão em classes separadas no seu projeto.*/
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }
    }
}