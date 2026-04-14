# 💈 Barbershop 

Sistema fullstack para gestão de barbearias, focado em **arquitetura limpa, escalabilidade e experiência do usuário**.

---

## 🚀 Tecnologias Utilizadas

### 🔧 Backend
- .NET 8
- C#
- Clean Architecture
- CQRS (Command Query Responsibility Segregation)
- MediatR
- Domain Events
- Entity Framework Core

### 🎨 Frontend
- Angular 12
- TypeScript
- Reactive Forms
- Integração com API REST

---

## 🧠 Arquitetura

O projeto segue os princípios de **Clean Architecture**, garantindo separação de responsabilidades e alta manutenibilidade.

📦 Barbershop

┣ 📂 Barbershop.Api → Camada de apresentação (Controllers)

┣ 📂 Barbershop.Application → Regras de aplicação (CQRS, DTOs, Handlers)

┣ 📂 Barbershop.Domain → Entidades e regras de negócio

┣ 📂 Barbershop.Infra → Acesso a dados (EF Core, Repositórios)

┗ 📂 BarberShopAngularFront → Frontend Angular


---

## ⚙️ Funcionalidades

- Cadastro de clientes
- Cadastro de profissionais
- Cadastro de serviços
- Agendamento de horários
- Consulta por data
- Integração com envio de e-mail (Domain Events)

---

## 🔄 Fluxo Inteligente de Agendamento

Ao criar um agendamento:

1. O dado é persistido no banco
2. Um **Domain Event** é disparado
3. Um handler processa o envio de e-mail em background

✔️ Não bloqueia a requisição  
✔️ Melhora performance  
✔️ Sistema mais resiliente  

---

## 📡 Endpoints da API

### 📅 Agendamento

| Método | Rota | Descrição |
|------|------|----------|
| GET | `/api/Agendamento` | Lista todos os agendamentos |
| POST | `/api/Agendamento` | Cria um novo agendamento |
| GET | `/api/Agendamento/{id}` | Busca por ID |
| PUT | `/api/Agendamento/{id}` | Atualiza agendamento |
| DELETE | `/api/Agendamento/{id}` | Remove agendamento |
| GET | `/api/Agendamento/por-data/{data}` | Busca por data |

---

### 👤 Cliente

| Método | Rota | Descrição |
|------|------|----------|
| GET | `/api/Cliente` | Lista todos os clientes |
| POST | `/api/Cliente` | Cria novo cliente |
| GET | `/api/Cliente/{id}` | Busca por ID |
| PUT | `/api/Cliente/{id}` | Atualiza cliente |
| DELETE | `/api/Cliente/{id}` | Remove cliente |

---

### 💼 Profissional

| Método | Rota | Descrição |
|------|------|----------|
| GET | `/api/Profissional` | Lista todos |
| POST | `/api/Profissional` | Cria novo |
| GET | `/api/Profissional/{id}` | Busca por ID |
| PUT | `/api/Profissional/{id}` | Atualiza |
| DELETE | `/api/Profissional/{id}` | Remove |

---

### ✂️ Serviço

| Método | Rota | Descrição |
|------|------|----------|
| GET | `/api/Servico` | Lista todos |
| POST | `/api/Servico` | Cria novo |
| GET | `/api/Servico/{id}` | Busca por ID |
| PUT | `/api/Servico/{id}` | Atualiza |
| DELETE | `/api/Servico/{id}` | Remove |

