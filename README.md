Aqui está um **README.md pronto, organizado e profissional** para você copiar direto pro seu projeto 👇

***

# 🚀 API Clínica - .NET + PostgreSQL + Dapper

API desenvolvida em **.NET (C#)** utilizando:

* ✅ PostgreSQL
* ✅ Dapper (ORM leve)
* ✅ Arquitetura em camadas
* ✅ Queries organizadas em `/Infrastructure/Data`

***

## 📋 Pré-requisitos

Antes de iniciar, instale:

* ✅ <https://dotnet.microsoft.com/download>
* ✅ <https://www.postgresql.org/download/>
* ✅ Gerenciador de banco (opcional, recomendado):
  * DBeaver
  * PgAdmin

***

## 📦 Clonando o projeto

```bash
git clone https://github.com/seu-usuario/seu-repositorio.git
cd seu-repositorio
```

***

## 🐘 Configuração do Banco de Dados (PostgreSQL)

### 1. Criar o banco

Abra o PostgreSQL e execute:

```sql
CREATE DATABASE clinica;
```

***

### 2. Executar os scripts SQL

As queries estão organizadas em:

```
/Infrastructure/Data
```

👉 Execute os scripts manualmente no banco (`SELECT`, `CREATE TABLE`, etc.)

Exemplo de criação de tabela:

```sql
CREATE TABLE users (
    id SERIAL PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    email VARCHAR(150),
    status INT
);
```

***

### 3. Configurar a Connection String

Abra o arquivo:

```
appsettings.json
```

Edite:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=clinica;Username=postgres;Password=sua_senha"
}
```

***

## ⚙️ Rodando a aplicação

### 1. Restaurar dependências

```bash
dotnet restore
```

***

### 2. Executar o projeto

```bash
dotnet run
```

Ou via Visual Studio:

👉 Pressione **F5**

***

## 🌐 Acesso à API

Após rodar, a API estará disponível em:

```
https://localhost:5001
```

Swagger:

```
https://localhost:5001/swagger
```

***

## 📁 Estrutura do Projeto

```
/API                 → Controllers (entrada da aplicação)
/Application         → Regras de negócio
/Infrastructure      → Acesso a dados (Dapper)
/Infrastructure/Data → Queries SQL separadas
```

***

## 🧠 Uso do Dapper

O projeto utiliza Dapper para consultas ao banco.

Exemplo:

```csharp
using (var connection = new NpgsqlConnection(connectionString))
{
    var sql = "SELECT * FROM users";
    var users = await connection.QueryAsync<User>(sql);
}
```

***

## 🔎 Organização das Queries

As queries SQL são mantidas separadas dentro de:

```
/Infrastructure/Data
```

✔ Boa prática: separar por entidade  
Ex:

```
UserQueries.sql
AppointmentQueries.sql
```

***

## ⚠️ Problemas comuns

### ❌ Falha ao conectar no banco

Verifique:

* PostgreSQL está rodando
* Usuário e senha corretos
* Porta (default 5432)

***

### ❌ Tabela não encontrada

Você precisa executar os scripts SQL manualmente.

***

### ❌ Porta já em uso

Altere no:

```
Properties/launchSettings.json
```

Exemplo:

```json
"applicationUrl": "https://localhost:5002"
```

***

## ✅ Dicas

* Sempre inicie o PostgreSQL antes da API
* Como usa Dapper, o controle do banco é manual (sem migrations automáticas)
* Organize as queries para manter o projeto limpo

***

## 📬 Contribuição

Sinta-se livre para abrir PR ou Issue 🚀

***

## 📌 Observações

* Este projeto não utiliza Entity Framework
* Toda a lógica SQL está separada para melhor controle e performance

