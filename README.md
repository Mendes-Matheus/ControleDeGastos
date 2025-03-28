# Controle de Gastos API

Este projeto é uma API para controle de gastos, permitindo o gerenciamento de pessoas e transações financeiras. A API é construída utilizando ASP.NET Core e segue o padrão RESTful.

## Funcionalidades

A API possui os seguintes controladores:

1. **PessoaController**: Gerencia as operações relacionadas a pessoas.
  
  - **POST /api/pessoa/save**: Salva uma nova pessoa.
  - **GET /api/pessoa/findById/{idPessoa}**: Busca uma pessoa pelo ID.
  - **GET /api/pessoa/findAll**: Busca todas as pessoas cadastradas.
2. **TransacaoController**: Gerencia as operações relacionadas a transações financeiras.
  
  - **POST /api/transacao/save/{pessoaId}**: Salva uma nova transação associada a uma pessoa.
  - **GET /api/transacao/getAll**: Retorna todas as transações registradas no sistema.
3. **TransferenciaController**: Gerencia as operações de transferência entre pessoas.
  
  - **POST /api/transferencia/transferir/{remetenteId}/{destinatarioId}**: Realiza uma transferência de valor entre duas pessoas.

## Acessando a API

### Swagger

A API está configurada para usar o Swagger, que fornece uma interface gráfica para testar os endpoints.

### Testando os Endpoints

Na interface do Swagger, você pode interagir com os endpoints da API. Aqui estão alguns exemplos de como usar o Swagger:

- **Salvar uma nova pessoa**:
  
  - Clique no endpoint `POST /api/pessoa/save`.
  - Clique em "Try it out".
  - Preencha os campos necessários no corpo da requisição (por exemplo, `nome` e `idade`).
  - Clique em "Execute" para enviar a requisição.
- **Buscar uma pessoa por ID**:
  
  - Clique no endpoint `GET /api/pessoa/findById/{idPessoa}`.
  - Insira um ID válido no campo `{idPessoa}`.
  - Clique em "Execute".
- **Buscar todas as pessoas**:
  
  - Clique no endpoint `GET /api/pessoa/findAll`.
  - Clique em "Execute" para obter a lista de todas as pessoas.
- **Salvar uma nova transação**:
  
  - Clique no endpoint `POST /api/transacao/save/{pessoaId}`.
  - Insira um ID de pessoa válido no campo `{pessoaId}` e preencha o corpo da requisição.
  - Clique em "Execute".
- **Obter todas as transações**:
  
  - Clique no endpoint `GET /api/transacao/getAll`.
  - Clique em "Execute" para obter todas as transações registradas.
- **Realizar uma transferência**:
  
  - Clique no endpoint `POST /api/transferencia/transferir/{remetenteId}/{destinatarioId}`.
  - Insira os IDs do remetente e destinatário e preencha o corpo da requisição.
  - Clique em "Execute".

## Estrutura do Projeto

- **DTO**: Contém os objetos de transferência de dados utilizados nas requisições e respostas.
- **Model**: Contém as classes de modelo que representam as entidades do sistema.
- **Service**: Contém as interfaces e implementações dos serviços que realizam a lógica de negócio.
- **Controllers**: Contém os controladores que expõem as APIs.

### Pré-requisitos

- .NET 8.0
- Banco de dados SQL Server
