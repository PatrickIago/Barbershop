# 📅 [BarberShop] - API de Agendamento de Serviços

![GitHub language count](https://img.shields.io/github/languages/count/PatrickIago/ShoppingCart.API)
![GitHub top language](https://img.shields.io/github/languages/top/PatrickIago/ShoppingCart.API)
[![.NET 8](https://img.shields.io/badge/.NET-8-512BD4?logo=dotnet)](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
[![Dapper](https://img.shields.io/badge/Dapper-ORM-F7A100)](https://dapper-tutorial.net/)
[![SMTP Mail](https://img.shields.io/badge/Email_Service-SMTP-D14836?logo=gmail)](https://en.wikipedia.org/wiki/Simple_Mail_Transfer_Protocol)
[![License](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)

---

## 🎯 Sobre o Projeto

Esta é uma **API RESTful** desenvolvida com **ASP.NET Core 8** para gerenciar serviços de agendamento (ideal para barbearias, salões ou consultórios).

O foco desta aplicação está em **performance** e **confiabilidade**, utilizando o *micro-ORM* **Dapper** para acesso rápido e eficiente ao banco de dados.

### ✨ Funcionalidade Chave: Notificação por E-mail

A aplicação inclui um recurso essencial de comunicação:
✅  **Um serviço SMTP** que envia um e-mail de confirmação ou notificação **automaticamente** toda vez que um novo agendamento é criado (`POST /api/Agendamento`).

## 🛠️ Tecnologias Utilizadas

* **Framework:** ASP.NET Core 8 (C#)
* **Acesso a Dados:** Dapper (Micro-ORM)
* **Banco de Dados:** [**AQUI: Insira o SGBD que você usou, ex: SQL Server, PostgreSQL**]
* **Comunicação:** Cliente SMTP
* **Documentação:** Swagger/OpenAPI

## 📦 Estrutura da API (Endpoints)

A API é dividida em quatro áreas principais, cobrindo as operações **CRUD (Create, Read, Update, Delete)** para cada recurso.

| Recurso | Método | Rota | Descrição |
| :--- | :--- | :--- | :--- |
| **Agendamento** | `POST` | `/api/Agendamento` | **[CREATE]** Cria um novo agendamento (**GATILHO DE E-MAIL**). |
| | `GET` | `/api/Agendamento` | **[READ ALL]** Retorna todos os agendamentos. |
| | `GET` | `/api/Agendamento/{id}` | **[READ ONE]** Retorna um agendamento específico. |
| | `GET` | `/api/Agendamento/por-data/{data}` | Busca agendamentos por data. |
| | `PUT` | `/api/Agendamento/{id}` | **[UPDATE]** Atualiza um agendamento. |
| | `DELETE` | `/api/Agendamento/{id}` | **[DELETE]** Remove um agendamento. |
| **Cliente** | `POST` | `/api/Cliente` | **[CREATE]** Adiciona um novo cliente. |
| | `GET` | `/api/Cliente` | **[READ ALL]** Lista todos os clientes. |
| | `GET` | `/api/Cliente/{id}` | **[READ ONE]** Retorna um cliente específico. |
| | `PUT` | `/api/Cliente/{id}` | **[UPDATE]** Atualiza os dados de um cliente. |
| | `DELETE` | `/api/Cliente/{id}` | **[DELETE]** Remove um cliente. |
| **Profissional** | `POST` | `/api/Profissional` | **[CREATE]** Adiciona um novo profissional. |
| | `GET` | `/api/Profissional` | **[READ ALL]** Lista todos os profissionais. |
| | `GET` | `/api/Profissional/{id}` | **[READ ONE]** Retorna um profissional específico. |
| | `PUT` | `/api/Profissional/{id}` | **[UPDATE]** Atualiza os dados de um profissional. |
| | `DELETE` | `/api/Profissional/{id}` | **[DELETE]** Remove um profissional. |
| **Serviço** |
