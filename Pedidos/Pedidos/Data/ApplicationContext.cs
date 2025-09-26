using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pedidos.Domain;

namespace Pedidos.Data
{
    public class ApplicationContext : DbContext // estabelece a conexao com o banco de dados
    {
        private static readonly ILoggerFactory _logger = LoggerFactory.Create(p => p.AddConsole()); // loga no console as operacoes do EF Core
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Cliente> Clientes { get; set; } 
        public DbSet<Produto> Produtos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // informar qual banco de dados (provider)
        {
            optionsBuilder
                .UseLoggerFactory(_logger) 
                .EnableSensitiveDataLogging() // loga os dados sensiveis (valores dos campos)
                .UseSqlServer("Server=SALGADO;Database=LojaDB;Trusted_Connection=True;TrustServerCertificate=True;"); // string de conexao
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // configurar as entidades (tabelas)
        {
            /* Esta única linha encontra e aplica TODAS as configurações
            que estão em classes separadas no seu projeto.*/
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }
    }
}