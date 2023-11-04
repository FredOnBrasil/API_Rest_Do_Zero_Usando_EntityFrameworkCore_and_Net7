# API REST de Gerenciamento de Eventos
---
Este é um projeto de API REST desenvolvido com o ASP.NET Core e o Entity Framework Core para gerenciar eventos. Esta API permite criar, ler, atualizar e excluir eventos, bem como realizar outras operações relacionadas a eventos.

# Requisitos
---
.NET 7.0 SDK
* Visual Studio ou Visual Studio Code (ou outra IDE de sua escolha)
* Banco de dados SQL Server (ou outro banco de dados suportado pelo Entity Framework Core)
* Postman (ou outra ferramenta para testar APIs)
* Neste projeto utilizamos banco de dados in memory para facilitar a visualização dos funcionamento
* Está devidamente documentado com o uso de swagger.

# Endpoints da API
---
Aqui estão os principais endpoints da API:

* GET /api/eventos: Recupera a lista de todos os eventos.
* GET /api/eventos/{id}: Recupera um evento específico com base no ID.
* POST /api/eventos: Cria um novo evento.
* PUT /api/eventos/{id}: Atualiza os detalhes de um evento existente.
* DELETE /api/eventos/{id}: Exclui um evento com base no ID.
Certifique-se de verificar a documentação completa da API para obter mais informações sobre os endpoints, os formatos de dados e os cabeçalhos de solicitação suportados.
---

# Testando a API
---
Você pode usar o Postman ou outra ferramenta semelhante para testar a API. Importe a coleção de exemplos de solicitações que está incluída neste repositório para facilitar os testes.

# Contribuições
---
Contribuições são bem-vindas! Sinta-se à vontade para abrir problemas, propor solicitações de pull ou melhorar a documentação.
