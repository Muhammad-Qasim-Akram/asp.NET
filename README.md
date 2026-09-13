# 🎮 GameStore API

A modern REST API for managing a game store, built with **ASP.NET Core 10** and **Entity Framework Core**. This project demonstrates clean architecture principles with organized endpoints, data models, and database migrations.

---

## ✨ Features

- 🔄 **RESTful API Design** - Clean, intuitive endpoints for game management
- 🗄️ **Entity Framework Core** - Seamless database operations with migrations
- 🏗️ **Clean Architecture** - Well-organized code structure with separation of concerns
- 📝 **DTOs** - Data transfer objects for request/response validation
- 🔗 **Genre Management** - Support for categorizing games
- 🚀 **Ready for Deployment** - Configured for both development and production environments

---

## 🛠️ Tech Stack

| Technology | Version | Purpose |
|------------|---------|---------|
| **.NET** | 10.0 | Runtime & Framework |
| **ASP.NET Core** | Latest | Web API Framework |
| **Entity Framework Core** | Latest | ORM for Database |
| **C#** | Latest | Programming Language |

---

## 🚀 Getting Started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/sql-server) or your preferred database

### Installation

1. **Clone the repository**
   ```bash
   git clone <repository-url>
   cd GameStore
   ```

2. **Restore dependencies**
   ```bash
   dotnet restore
   ```

3. **Update the database**
   ```bash
   dotnet ef database update
   ```

4. **Run the application**
   ```bash
   dotnet run --project GameStore.Api
   ```

The API will be available at `https://localhost:7XXX`

---

## 📁 Project Structure

```
GameStore.Api/
├── Data/                 # Database context and migrations
├── Models/              # Core domain models (Game, Genre)
├── Dtos/                # Data Transfer Objects
├── Endpoints/           # API endpoint definitions
├── Properties/          # Launch settings and project metadata
└── Program.cs           # Application entry point
```

### Key Components

- **GameStoreContext** - EF Core database context
- **Game** - Core game model with relationships
- **Genre** - Game category classification
- **GameEndpoints** - API route handlers
- **DTOs** - CreateGameDto, GameDto, UpdateGameDto

---

## 🔌 API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| `GET` | `/games` | Retrieve all games |
| `GET` | `/games/{id}` | Get a specific game |
| `POST` | `/games` | Create a new game |
| `PUT` | `/games/{id}` | Update a game |
| `DELETE` | `/games/{id}` | Delete a game |

---

## 🗄️ Database

The project uses **Entity Framework Core** with automatic migrations. The database includes:

- **Games** - Game catalog with pricing and descriptions
- **Genres** - Game category classification

Migrations are located in `GameStore.Api/Data/Migrations/`

---

## 🔧 Configuration

Configuration files are located in the root of `GameStore.Api/`:

- `appsettings.json` - Base configuration
- `appsettings.Development.json` - Development-specific settings
- `appsettings.local.json` - Local overrides (not tracked in git)

---

## 📊 Development

### Build
```bash
dotnet build
```

### Test
```bash
dotnet test
```

### Run with Hot Reload
```bash
dotnet watch run --project GameStore.Api
```

---

## 📝 License

This project is licensed under the MIT License - see the LICENSE file for details.

---

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

---

**Happy coding! 🚀**
