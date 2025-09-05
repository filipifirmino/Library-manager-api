# 📚 Library Manager API

<div align="center">

![.NET](https://img.shields.io/badge/.NET-8.0-purple?style=for-the-badge&logo=dotnet)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![MySQL](https://img.shields.io/badge/MySQL-00000F?style=for-the-badge&logo=mysql&logoColor=white)
![Entity Framework](https://img.shields.io/badge/Entity%20Framework-512BD4?style=for-the-badge&logo=entity-framework&logoColor=white)

**Um sistema de gerenciamento de biblioteca desenvolvido como projeto de estudos** 🎓

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg?style=for-the-badge)](https://opensource.org/licenses/MIT)

</div>

---

## 🎯 Sobre o Projeto

O **Library Manager API** é um projeto de estudos que implementa um sistema completo de gerenciamento de biblioteca utilizando **Clean Architecture** e **Domain-Driven Design (DDD)**. Este projeto foi desenvolvido para praticar conceitos avançados de desenvolvimento .NET, incluindo:

- 🏗️ **Arquitetura Limpa** com separação clara de responsabilidades
- 🎯 **Domain-Driven Design** com entidades e value objects bem definidos
- 🔄 **Padrão Repository** para abstração da camada de dados
- 🌐 **API RESTful** com documentação Swagger
- 🗄️ **Entity Framework Core** com MySQL
- 📦 **Injeção de Dependência** nativa do .NET

> ⚠️ **Importante**: Este é um projeto de estudos e não deve ser usado em produção sem as devidas validações e melhorias de segurança.

---

## 🚀 Funcionalidades

### 📖 Gestão de Livros
- ✅ Cadastro, edição e remoção de livros
- ✅ Categorização por gêneros (Romance, Terror, Manga, etc.)
- ✅ Controle de status (Disponível, Alugado, Indisponível)
- ✅ Sistema de ISBN para identificação única

### 👨‍💼 Gestão de Autores
- ✅ Cadastro completo de autores
- ✅ Biografia e data de nascimento
- ✅ Relacionamento com livros

### 👥 Gestão de Clientes
- ✅ Cadastro de clientes com dados pessoais
- ✅ Sistema de pontuação (Score)
- ✅ Contato e endereço

### 📋 Sistema de Empréstimos
- ✅ Controle de empréstimos e devoluções
- ✅ Períodos diferenciados (VIP: 20 dias, Simples: 10 dias)
- ✅ Verificação de prazo de devolução
- ✅ Histórico completo de empréstimos

---

## 🏗️ Arquitetura do Projeto

```
LibraryManager/
├── 📁 LibraryManager.ApplicationCore/     # Camada de Domínio
│   ├── 📁 Domain/                        # Entidades e Regras de Negócio
│   │   ├── 📁 Entities/                  # Book, Author, Customer, Rent
│   │   ├── 📁 Enum/                      # Category, Status, RentPeriod
│   │   └── 📁 ValueObject/               # Result, RentPeriod
│   ├── 📁 Gateway/                       # Interfaces de Acesso a Dados
│   ├── 📁 UseCases/                      # Casos de Uso da Aplicação
│   └── 📁 Configure/                     # Configurações da Camada
├── 📁 LibraryManager.Infra/              # Camada de Infraestrutura
│   ├── 📁 Config/                        # DataContext e Configurações
│   ├── 📁 Entity/                        # Entidades do EF Core
│   ├── 📁 Gateways/                      # Implementações dos Gateways
│   ├── 📁 Mappers/                       # Conversores entre Camadas
│   ├── 📁 Repositores/                   # Implementações dos Repositórios
│   └── 📁 Migrations/                    # Migrações do Banco de Dados
└── 📁 LibraryManager.Web/                # Camada de Apresentação
    ├── 📁 Controllers/                   # Controllers da API
    ├── 📁 Requests/                      # DTOs de Requisição
    ├── 📁 Responses/                     # DTOs de Resposta
    └── 📁 Configure/                     # Configurações da Web
```

---

## 🛠️ Tecnologias Utilizadas

### Backend
- **.NET 8.0** - Framework principal
- **ASP.NET Core Web API** - Para criação da API REST
- **Entity Framework Core 8.0** - ORM para acesso a dados
- **Pomelo.EntityFrameworkCore.MySql** - Provider MySQL
- **Swagger/OpenAPI** - Documentação da API

### Banco de Dados
- **MySQL 8.0** - Banco de dados relacional

### Padrões e Conceitos
- **Clean Architecture** - Separação de responsabilidades
- **Domain-Driven Design** - Modelagem orientada ao domínio
- **Repository Pattern** - Abstração da camada de dados
- **Dependency Injection** - Inversão de controle
- **CQRS** - Separação de comandos e consultas

---

## ⚙️ Configuração e Execução

### Pré-requisitos
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [MySQL 8.0](https://dev.mysql.com/downloads/mysql/)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) ou [VS Code](https://code.visualstudio.com/)

### Instalação

1. **Clone o repositório**
   ```bash
   git clone https://github.com/seu-usuario/library-manager-api.git
   cd library-manager-api
   ```

2. **Configure o banco de dados**
   - Crie um banco MySQL chamado `DB_MANAGER_BOOK`
   - Atualize a connection string em `appsettings.json` se necessário

3. **Execute as migrações**
   ```bash
   dotnet ef database update --project LibraryManager.Infra --startup-project LibraryManager.Web
   ```

4. **Execute a aplicação**
   ```bash
   dotnet run --project LibraryManager.Web
   ```

5. **Acesse a documentação**
   - Swagger UI: `https://localhost:7000/swagger`
   - API Base: `https://localhost:7000/api/v1`

---

## 📚 Endpoints da API

### 📖 Livros (`/api/v1/Book`)
- `GET /all-books` - Lista todos os livros
- `GET /get-books` - Busca livro por ID
- `POST /register-books` - Cadastra novo livro
- `PUT /update-books` - Atualiza livro existente
- `DELETE /remove-books` - Remove livro

### 👨‍💼 Autores (`/api/v1/Author`)
- `GET /all-authors` - Lista todos os autores
- `GET /get-authors` - Busca autor por ID
- `POST /register-authors` - Cadastra novo autor
- `PUT /update-authors` - Atualiza autor existente
- `DELETE /remove-authors` - Remove autor

### 👥 Clientes (`/api/v1/Customer`)
- `GET /all-customers` - Lista todos os clientes
- `GET /get-customers` - Busca cliente por ID
- `POST /register-customers` - Cadastra novo cliente
- `PUT /update-customers` - Atualiza cliente existente
- `DELETE /remove-customers` - Remove cliente

### 📋 Empréstimos (`/api/v1/Rent`)
- `GET /` - Lista todos os empréstimos
- `GET /byId` - Busca empréstimo por ID
- `POST /rent` - Cria novo empréstimo

---

## 🎓 Conceitos Aplicados

### Clean Architecture
- **Separação de responsabilidades** em camadas bem definidas
- **Inversão de dependência** com interfaces
- **Independência de frameworks** na camada de domínio

### Domain-Driven Design
- **Entidades** com identidade única (Book, Author, Customer, Rent)
- **Value Objects** para conceitos sem identidade (Result, RentPeriod)
- **Enums** para representar conceitos do domínio (Category, Status)

### Padrões de Projeto
- **Repository Pattern** para abstração do acesso a dados
- **Gateway Pattern** para comunicação entre camadas
- **Use Case Pattern** para encapsular regras de negócio

---

## 🔮 Melhorias Futuras

- [ ] Implementar autenticação e autorização
- [ ] Adicionar validações mais robustas
- [ ] Implementar logs estruturados
- [ ] Adicionar testes unitários e de integração
- [ ] Implementar cache para melhor performance
- [ ] Adicionar documentação XML para a API
- [ ] Implementar paginação nas consultas
- [ ] Adicionar sistema de notificações para empréstimos vencidos

---

## 📝 Licença

Este projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.

---

## 👨‍💻 Autor

**Filipi** - Desenvolvedor em aprendizado contínuo

> 💡 **Dica**: Este projeto foi desenvolvido como parte do portfólio de estudos. Sinta-se à vontade para explorar o código e sugerir melhorias!

---

<div align="center">

**Desenvolvido com ❤️ para fins educacionais**

![Made with .NET](https://img.shields.io/badge/Made%20with-.NET-purple?style=for-the-badge&logo=dotnet)

</div>
