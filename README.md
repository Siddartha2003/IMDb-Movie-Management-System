# IMDb Movie Management System

A minimal RESTful API built with .NET 8 for managing movies, actors, producers, genres, and reviews. This project is a demonstration using in-memory repositories and JWT Bearer authentication for protected endpoints.

## Table of contents
- [Features](#features)
- [Tech stack](#tech-stack)
- [Prerequisites](#prerequisites)
- [Quick start](#quick-start)
- [Configuration](#configuration)
- [Running the app](#running-the-app)
- [API endpoints](#api-endpoints)
- [Authentication](#authentication)
- [Data persistence](#data-persistence)
- [Testing](#testing)
- [Contributing](#contributing)
- [License](#license)

## Features
- CRUD operations for Movies, Actors, Producers, Genres and Reviews
- JWT Bearer authentication for protected endpoints
- Simple dependency-injected services and in-memory repositories
- Clear, RESTful controller routes for easy testing and extension

## Tech stack
- .NET 8
- C# (latest supported by the project)
- No external database (in-memory lists)

## Prerequisites
- .NET 8 SDK — https://dotnet.microsoft.com
- Visual Studio 2022 or VS Code (optional)
- curl, httpie, or Postman for testing

## Quick start
1. Clone repository:
2. Restore and build:

## Configuration
- The development JWT secret is hard-coded in `Program.cs` and `Controllers/AuthController.cs` as `THIS_IS_MY_SUPER_SECRET_KEY_123456789`. Replace and store securely (environment variable, secrets manager) for any non-demo use.
- Local launch URLs are in `Properties/launchSettings.json` (examples: `https://localhost:7264`, `http://localhost:5210`).

Recommended production changes:
- Replace in-memory stores with a database (EF Core + DbContext).
- Move JWT secret and other secrets to secure configuration.
- Implement password hashing, validation, input validation, and structured error responses.
- Add logging, health checks, and tests.

## Running the app
Run from CLI:

Or open in Visual Studio 2022 and run with the desired profile (IIS Express or project).

When running locally prefer the `https` profile (e.g. `https://localhost:7264`).

## API endpoints
Public (no auth)
- `POST /auth/signup` — register a user
- `POST /auth/login` — login and receive JWT

Protected (require `Authorization: Bearer <token>`)
- Movies
  - `GET /movies` — list movies (optional `?year=YYYY`)
  - `GET /movies/{id}` — get movie by id
  - `POST /movies` — create movie
  - `PUT /movies/{id}` — update movie
  - `DELETE /movies/{id}` — delete movie
- Actors
  - `GET /actors`, `GET /actors/{id}`, `POST /actors`, `PUT /actors/{id}`, `DELETE /actors/{id}`
- Producers
  - `GET /producers`, `GET /producers/{id}`, `POST /producers`, `PUT /producers/{id}`, `DELETE /producers/{id}`
- Genres
  - `GET /genres`, `GET /genres/{id}`, `POST /genres`, `PUT /genres/{id}`, `DELETE /genres/{id}`
- Reviews
  - `GET /reviews`, `GET /reviews/{id}`, `GET /reviews/movie/{movieId}`, `POST /reviews`, `PUT /reviews/{id}`, `DELETE /reviews/{id}`

## Authentication
1. Signup (public):
2. Login (public):

Login response:
Use the returned token to call protected endpoints:

Notes:
- All resource controllers are decorated with `[Authorize]`. Include the JWT in the `Authorization` header for those endpoints.

## Data persistence
- Current repositories use in-memory `List<T>` and lose data on restart. See `Auth/AuthRepository.cs` and `Repositories/Implementations/*`.

To add persistence:
- Add EF Core, define a `DbContext`, implement repositories against the database, and configure migrations/connection strings.

## Testing
- Use Postman, curl, or httpie:
  1. Register via `/auth/signup`
  2. Login via `/auth/login` to obtain token
  3. Call protected endpoints with `Authorization: Bearer <token>`

## Contributing
- Fork the repository, create feature branches, and open PRs against `main`.
- Add tests for new functionality and follow project coding conventions.

## License
- No license file is included.
