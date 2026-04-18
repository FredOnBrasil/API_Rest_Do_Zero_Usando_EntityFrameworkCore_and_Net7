# DevEventAPI

## API REST de Gerenciamento de Eventos

### Visão Geral

Esta é uma API REST desenvolvida com ASP.NET Core e Entity Framework Core para gerenciamento completo de eventos. A implementação segue boas práticas de arquitetura e desenvolvimento, proporcionando uma solução robusta e escalável para gerenciamento de eventos.

---

### Arquitetura e Tecnologias

#### Tecnologias Utilizadas
- **ASP.NET Core 7.0** - Framework principal para desenvolvimento de API
- **Entity Framework Core** - ORM para persistência de dados
- **SQL Server** - Banco de dados relacional (suporte a outros bancos via EF Core)
- **Swagger/OpenAPI** - Documentação automática da API
- **Injeção de Dependências** - Padrão de injeção de dependências do .NET

#### Padrões de Design Implementados
- **Controller-Service Pattern** - Separação de responsabilidades
- **Repository Pattern** - Abstração de acesso a dados
- **Dependency Injection** - Injeção de dependências com container nativo
- **RESTful API Design** - Conformidade com práticas REST

---

### Recursos Funcionais

#### Operações CRUD Completa
- **GET /api/eventos** - Recuperação de todos os eventos com paginação
- **GET /api/eventos/{id}** - Recuperação de evento específico por ID
- **POST /api/eventos** - Criação de novos eventos
- **PUT /api/eventos/{id}** - Atualização completa de eventos
- **DELETE /api/eventos/{id}** - Exclusão de eventos

---

#### Características Técnicas
- **Validação de Dados** - Validação de entrada com model binding
- **Tratamento de Erros** - Respostas HTTP adequadas (200, 201, 404, 400, etc.)
- **Auditoria** - Registro de transações e operações
- **Performance** - Otimização de consultas com Entity Framework Core

---

### Estrutura de Dados

#### Modelo de Dados - Evento
```csharp
public class Evento
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    public string Organizador { get; set; }
    public DateTime DataCriacao { get; set; }
}
```

---

### Configuração e Execução

#### Requisitos de Sistema
- .NET 7.0 SDK
- Visual Studio 2022 ou Visual Studio Code
- SQL Server ou SQL Server Express
- Postman ou ferramenta similar para testes

#### Configuração Inicial
1. Clonar o repositório
2. Restaurar pacotes NuGet
3. Configurar string de conexão no `appsettings.json`
4. Executar migrações do Entity Framework
5. Iniciar a aplicação

---

### Documentação da API

#### Endpoints Disponíveis

**GET /api/eventos**
- Retorna lista completa de eventos
- Status: 200 OK

**GET /api/eventos/{id}**
- Retorna evento específico por ID
- Status: 200 OK / 404 Not Found

**POST /api/eventos**
- Cria novo evento
- Status: 201 Created

**PUT /api/eventos/{id}**
- Atualiza evento existente
- Status: 204 No Content / 404 Not Found

**DELETE /api/eventos/{id}**
- Remove evento por ID
- Status: 204 No Content / 404 Not Found

### Melhorias Implementadas

#### Segurança
- Validação de entrada de dados
- Tratamento adequado de erros HTTP
- Proteção contra SQL Injection

#### Performance
- Otimização de consultas com Entity Framework Core
- Uso eficiente de memória
- Indexação de campos críticos

#### Manutenibilidade
- Código altamente documentado com XML Comments
- Estrutura de projeto modular

### Práticas de Desenvolvimento

#### Injeção de Dependências
```csharp
public EventosController(EventosDbContext contexto)
{
    _contexto = contexto;
}
```

---

#### Validação de Dados
- Model binding com validação automática
- Tratamento de erros com códigos HTTP apropriados
- Feedback claro para consumidores da API

### Contribuições

Este projeto está estruturado para facilitar contribuições:
- Código com documentação XML
- Estrutura de projeto clara
- Padrões de desenvolvimento consistente
- Testes de integração

### Autor

[Frederico Aguiar]

---
