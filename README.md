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
* **Banco de Dados:** [**SQL Server**]
* **Comunicação:** Cliente SMTP
* **Documentação:** Swagger/OpenAPI

## 📦 Estrutura da API (Endpoints)

A API é dividida em quatro áreas principais, cobrindo as operações CRUD (Criar, Ler, Atualizar, Deletar) para cada recurso:

| Recurso | Método | Rota | Descrição |
| :--- | :--- | :--- | :--- |
| **Agendamento** | `POST` | `/api/Agendamento` | **Cria um novo agendamento (GATILHO DE E-MAIL).** |
| | `GET` | `/api/Agendamento/por-data/{data}` | Busca agendamentos por data. |
| | `GET` | `/api/Agendamento` | Retorna todos os agendamentos. |
| | `PUT` | `/api/Agendamento/{id}` | Atualiza agendamento. |
| | `DELETE` | `/api/Agendamento/{id}` | Remove agendamento. |
| **Cliente** | `POST` | `/api/Cliente` | Adiciona um novo cliente. |
| | `GET` | `/api/Cliente` | Lista todos os clientes. |
| **Profissional** | `POST` | `/api/Profissional` | Adiciona um novo profissional. |
| | `GET` | `/api/Profissional` | Lista todos os profissionais. |
| **Serviço** | `POST` | `/api/Servico` | Adiciona um novo serviço. |
| | `GET` | `/api/Servico` | Lista todos os serviços. |
