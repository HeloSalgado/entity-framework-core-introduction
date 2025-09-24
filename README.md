# Introdução ao Entity Framework Core

![Status](https://img.shields.io/badge/Status-Em%20Desenvolvimento-brightgreen?style=for-the-badge)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Entity Framework Core](https://img.shields.io/badge/Entity%20Framework%20Core-512BD4?style=for-the-badge&logo=.net&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)

Este repositório é um projeto de estudo e demonstração dos conceitos fundamentais do **Entity Framework Core**, o ORM (Object-Relational Mapper) moderno, flexível e de código aberto da Microsoft para .NET.

O objetivo é apresentar de forma prática como configurar um projeto, mapear entidades de domínio para um banco de dados relacional e realizar operações básicas de persistência de dados.

## ✨ Tecnologias Utilizadas

  * **.NET** (Recomendado .NET 6 ou superior)
  * **Entity Framework Core**
  * **Microsoft SQL Server** (utilizado como provedor de banco de dados)

## 📚 Principais Conceitos Abordados

Este projeto demonstra na prática os seguintes pilares do EF Core:

  * ✔️ **DbContext**: Configuração do contexto de dados (`ApplicationContext.cs`) para gerenciar a sessão com o banco e mapear as classes de domínio.
  * ✔️ **DbSet**: Representação das tabelas do banco de dados (`Pedidos`, `Clientes`, `Produtos`).
  * ✔️ **Fluent API**: Mapeamento detalhado das entidades usando a interface `IEntityTypeConfiguration<T>`, separando as responsabilidades de configuração e mantendo o código organizado.
  * ✔️ **Mapeamento de Entidades**: Definição de chaves primárias (`HasKey`), tipos de coluna (`HasColumnType`), constraints (`IsRequired`, `HasMaxLength`) e nomes de tabelas (`ToTable`).
  * ✔️ **Relacionamentos**: Exemplos práticos de relacionamentos Um-para-Muitos (`HasOne`/`WithMany`) entre as entidades `Pedido`, `Cliente` e `PedidoItem`.
  * ✔️ **Value Objects**: Utilização de `Enums` e sua conversão para `string` ou `int` no banco de dados, simplificando o modelo de domínio.
  * ✔️ **Migrations**: Demonstração do fluxo de trabalho "Code-First", onde o banco de dados é gerado e atualizado a partir do código C\#.
  * ✔️ **Operações CRUD**: Exemplos de como Inserir, Consultar, Atualizar e Deletar dados utilizando o `DbContext`.

## 📁 Estrutura do Projeto

O código está organizado nos seguintes diretórios para facilitar o entendimento:

  * **`/Data`**: Contém a classe `ApplicationContext` (o DbContext) e as configurações de mapeamento via Fluent API na pasta `/Configurations`.
  * **`/Domain`**: Contém as classes de modelo (entidades) que representam os objetos de negócio da aplicação, como `Pedido`, `Cliente` e `Produto`.
  * **`/ValueObjects`**: Contém tipos simples, como `Enums`, que são usados pelas entidades de domínio.

## 🔧 Como Executar o Projeto

Siga os passos abaixo para configurar e rodar a aplicação em seu ambiente local.

### Pré-requisitos

  * **[.NET SDK](https://dotnet.microsoft.com/download)** (versão 6 ou superior).
  * **[SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)** (pode ser a versão Express ou Developer).
  * **EF Core Tools**: Instale a ferramenta de linha de comando do EF Core:
    ```bash
    dotnet tool install --global dotnet-ef
    ```

### Passos

1.  **Clone o repositório:**

    ```bash
    git clone https://github.com/HeloSalgado/entity-framework-core-introduction.git
    cd entity-framework-core-introduction
    ```

2.  **Configure a String de Conexão:**
    Abra o arquivo `Data/ApplicationContext.cs` e altere a string de conexão no método `OnConfiguring` para apontar para a sua instância do SQL Server. Principalmente, ajuste o `Server`.

    ```csharp
    // Exemplo em Data/ApplicationContext.cs
    optionsBuilder.UseSqlServer("Server=SEU_SERVIDOR;Database=LojaDB;Trusted_Connection=True;");
    ```

3.  **Aplique as Migrations:**
    No terminal, na raiz do projeto, execute o comando abaixo para criar o banco de dados `LojaDB` e todas as tabelas configuradas no código.

    ```bash
    dotnet ef database update
    ```

4.  **Execute a Aplicação:**
    O projeto está configurado como um Console Application. Para executá-lo, rode o seguinte comando:

    ```bash
    dotnet run
    ```

    Isso irá executar o código presente no arquivo `Program.cs`, que contém exemplos práticos de uso do EF Core.

## 👩‍💻 Autora

  * **Heloisa Salgado** - [GitHub](https://www.google.com/search?q=https://github.com/HeloSalgado)

-----