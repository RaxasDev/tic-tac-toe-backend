# Jogo da Velha - TicTacToe

Projeto realizado para entrevista técnica na empresa transobra.

## Tecnologias

- .NET 9
- C#
- Entity Framework Core
- Postgres SQL
- Swagger

## Pré-requisitos

- .NET SDK >= 8
- Postgres SQL
- CLI do .NET (dotnet)

## Configuração do Banco de Dados

1. Primeiramente será necessário configurar o banco de dados, sendo assim, crie um banco com qualquer SGBD, desde que seja utilizando Postgres SQL
2. Configurar no arquivo Appsettings.json a String de conexão padrão, para o nome do seu banco que criou, usuário e senha do seu postgres local.
3. Aplicar o comando `dotnet restore` para recuperar as dependências do projeto
4. Aplicar as migrations no banco, `dotnet ef database update`... Dependendo da IDE, algumas trazem algumas comodidades para aplicação das migrations,
como é o caso do Rider (Jetbrains).
5. Por padrão, ao inicializar, irá abrir o Browser com a página do Swagger, conforme está configurado no arquivo launch no projeto.
6. Caso ocorra algum problema ou feche a aba o endereço para o swagger é `http://localhost:5000/index.html`
