using Microsoft.EntityFrameworkCore;
using Pedidos.Data;
using Pedidos.Domain;
using Pedidos.ValueObjects;

using var db = new ApplicationContext();

// db.Database.Migrate(); // aplica as migrations pendentes

// var existe = db.Database.GetPendingMigrations().Any();
// Console.WriteLine(existe ? "Existe migration pendente" : "Banco de dados atualizado");

// InserirDados();
// InserirDadosEmMassa();
ConsultarDados();

static void InserirDados()
{
    var produto = new Produto
    {
        Descricao = "Produto Teste",
        CodigoBarras = "1234567890123",
        Valor = 10.99m,
        TipoProduto = TipoProduto.MercadoriaParaRevenda,
        Ativo = true
    };

    using var db = new ApplicationContext();
    db.Produtos.Add(produto);
    // outras formas de adicionar um registro
    // db.Set<Produto>().Add(produto);
    // db.Entry(produto).State = EntityState.Added;
    // db.Add(produto);
    db.SaveChanges();
    Console.WriteLine($"Produto {produto.Id} - {produto.Descricao} adicionado com sucesso!");
}

static void InserirDadosEmMassa()
{
    var produto = new Produto
    {
        Descricao = "Produto Teste 1",
        CodigoBarras = "1234567890123",
        Valor = 10.99m,
        TipoProduto = TipoProduto.MercadoriaParaRevenda,
        Ativo = true
    };

    var cliente = new Cliente
    {
        Nome = "Heloisa Salgado",
        Telefone = "11999999999",
        CEP = "12345678",
        Estado = "SP",
        Cidade = "São Paulo"
    };

    using var db = new ApplicationContext();
    db.AddRange(produto, cliente);

    var registros = db.SaveChanges();
    Console.WriteLine($"{registros} registros foram adicionados ao banco de dados.");
}

static void ConsultarDados()
{
    using var db = new ApplicationContext();
    // var consultaPorSintaxe = (from c in db.Clientes where c.Id > 0 select c).ToList();
    var consultaPorMetodo = db.Clientes
        .AsNoTracking()
        .Where(p => p.Id > 0)
        .OrderBy(p => p.Id) // ordena por Id
        .ToList();
}