# DevFreela

Projeto desenvolvido durante a formação de ASP.NET Core usando **.NET 6** para praticar uma API REST com padrões e ferramentas modernos.

Principais recursos empregados ao longo do curso:

- Swagger para documentação e testes rápidos dos endpoints
- Arquitetura limpa em camadas (Core, Infrastructure, Application, API)
- Entity Framework Core e Dapper para acesso a dados
- CQRS com MediatR
- Autenticação via JWT
- Testes unitários com xUnit
---

## Como rodar

1. `dotnet restore`
2. `dotnet build`
3. `dotnet run -p DevFreela.API/DevFreela.API.csproj`
4. (opcional) Defina `ASPNETCORE_ENVIRONMENT=Development` para Swagger em produção.

String de conexão: chave `DevFreelaCs` em `appsettings*.json`.

## Banco de dados / EF Core

- Aplicar migrations: `dotnet ef database update -s DevFreela.API/DevFreela.API.csproj`
- Criar migration: `dotnet ef migrations add <Nome> -s DevFreela.API/DevFreela.API.csproj`

## Autenticação (JWT)

Configurar `Jwt:Key`, `Jwt:Issuer`, `Jwt:Audience` em `appsettings*.json`. Endpoints protegidos requerem Bearer token no header `Authorization`.

## Estrutura da solução

- `Core`: entidades, enums, contratos.
- `Application`: commands/queries (MediatR), DTOs, validações.
- `Infrastructure`: EF/Dapper, repositórios, migrations, serviços externos.
- `API`: controllers, DI, pipeline HTTP.

## Endpoints principais

- Projetos: CRUD, iniciar/finalizar, comentários.
- Usuários: cadastro e perfis (cliente/freelancer).
- Skills: listar e vincular via `UserSkills`.

## Testes

- Executar: `dotnet test`

## Cuidados de versão

Projeto alvo .NET 5/6. Evitar pacotes incompatíveis (ex.: Microsoft.Bcl.AsyncInterfaces 9.x em net5.0 gera warning).

---

## Swagger

Ferramenta que gera a interface interativa dos endpoints, permitindo explorar e testar requisições diretamente no navegador.
![image](https://user-images.githubusercontent.com/76961685/128607463-b449e0ca-1b39-4cce-9b8e-38fb1fa469e2.png)

---
## Arquitetura Limpa

Seguindo a abordagem Onion Architecture, o domínio fica no centro e as dependências são direcionadas para dentro. As quatro camadas usadas:

- Core, Infrastructure, Application e API
![image](https://user-images.githubusercontent.com/76961685/128607691-bbeeb09f-aeaf-4baa-8019-fcd73942ca5a.png)

---

## Entity Framework Core

ORM oficial do .NET, multiplataforma e open-source. Pacotes utilizados:

~~~ csharp
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools

using Microsoft.EntityFrameworkCore;
~~~
![image](https://user-images.githubusercontent.com/76961685/128608246-d12db8a9-384f-4768-baba-f33989824431.png)

---

## Dapper

Micro-ORM com foco em performance, fácil de combinar com EF Core ou outros acessos a dados.

~~~ csharp
using Dapper;
~~~
![image](https://user-images.githubusercontent.com/76961685/128608179-b25a1d15-a999-4312-bc26-fd60d3cd110a.png)

--- 

## CQRS

~~~ csharp
Command-Query Responsibility Segregation
~~~
Separa consultas (Queries) das operações de escrita (Commands), melhorando legibilidade e organização das responsabilidades.
![image](https://user-images.githubusercontent.com/76961685/128608304-837169e1-c5de-4d4e-b518-d18860fc2429.png)

---

## MediatR

Biblioteca para roteamento interno de Commands e Queries aos seus Handlers.

Pacote: *MediatR.Extensions.Microsoft.DependencyInjection*
~~~ csharp
// Registro típico
services.AddMediatR(typeof(AlgumCommand));
~~~
![image](https://user-images.githubusercontent.com/76961685/128608476-44424e3c-f0bc-49a5-999a-5e9867fbdd35.png)

---

## Json Web Token - JWT

Token assinado contendo dados do usuário e da aplicação, trafegado no header `Authorization`. Usa chave secreta e algoritmo de hashing (ex.: SHA256) para validação.
![image](https://user-images.githubusercontent.com/76961685/128608610-bafab7cf-0145-49bc-99d0-e5e0b49e9d8a.png)

---

## xUnit

Framework de testes unitários moderno e open-source. Em um projeto xUnit basta criar a classe e usar `[Fact]` nos métodos de teste.

~~~ csharp
public class ProjectTests
{
    [Fact]
    public void TestIfProjectStartWorks()
    {
        var project = new Project("Nome De Teste", "Descricao de Teste", 1, 2, 10000);

        Assert.Equal(ProjectStatusEnum.Created, project.Status);
        Assert.Null(project.StartedAt);

        Assert.NotNull(project.Title);
        Assert.NotEmpty(project.Title);

        Assert.NotNull(project.Description);
        Assert.NotEmpty(project.Description);

        project.Start();

        Assert.Equal(ProjectStatusEnum.InProgress, project.Status);
        Assert.NotNull(project.StartedAt);
    }
}
~~~
