# API Fornecedor

Esta é uma API RESTful para gerenciamento de fornecedores.

## Configuração do Banco de Dados

Antes de executar o projeto, é necessário criar o banco de dados e a tabela de fornecedores. Siga os passos abaixo:

### Criar Banco de Dados

```sql
CREATE DATABASE APIFornecedor;
USE APIFornecedor;


CREATE TABLE fornecedor (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(255) NOT NULL,
    email VARCHAR(255) NOT NULL
);
```




## Endpoints Disponíveis

Após a configuração do banco de dados e a execução do projeto, os seguintes endpoints estarão disponíveis:

1. FindAll: Retorna todos os fornecedores.
	- GET: [https://localhost:44337/api/fornecedores]
2. FindById: Retorna um fornecedor específico com base no ID.
	- GET: [https://localhost:44337/api/fornecedores/{id}]
3. Create: Insere um fornecedor.
	- POST: [https://localhost:44337/api/fornecedores]
4. Update: Atualiza as informações de um fornecedor com base no ID. 
	- PUT: [https://localhost:44337/api/fornecedores/{id}]
5. Delete: Exclui um fornecedor com base no ID.
	- DELETE: [https://localhost:44337/api/fornecedores/{id}]


## Como Executar o Projeto
1. Certifique-se de que o banco de dados está configurado conforme descrito acima.
2. Clone o repositório do projeto.
3. Configure a string de conexão com o banco de dados MySQL no arquivo **appsettings.json**.
4. Execute o projeto usando o Visual Studio ou via dotnet run no terminal.


