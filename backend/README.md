## GETTING STARTED

To run this app locally, follow these steps. Development was done on Archlinux, but these steps should be easily replicable on any other distro. This should also be easy to do on Windows, but may require some tweaking.

### Prerequisites

* dotnet
* dotnet-sdk
* aspnet-runtime
* postgresql
* dotnet-ef

We are currently looking into using Docker for development, to avoid the need for manual installation of PSQL.

These can easily be installed using any package manager:

Debian-based distros
```sh
sudo dpkg -i packages-microsoft-prod.deb
sudo apt-get update
sudo apt-get install -y dotnet-runtime-8.0
sudo apt-get install -y dotnet-sdk-8.0
sudo apt-get install -y aspnetcore-runtime-8.0
sudo apt-get install -y postgresql
```

Redhat-based distros
```sh
sudo dnf update
sudo dnf install -y dotnet-runtime-8.0
sudo dnf install -y dotnet-sdk-8.0
sudo dnf install -y aspnetcore-runtime-8.0
sudo dnf install -y postgresql
```

Arch-based distros
```sh
sudo pacman -S dotnet dotnet-sdk aspnet-runtime postgresql
```
Additionally, to use `dotnet` tools from the shell, add the following to your PATH:
```sh
~/.dotnet/tools
```

Afterwards, for database integration install dotnet-ef using:
```
dotnet tool install --global dotnet-ef
```

Setting up PSQL can be somewhat involved, depending on your setup. For this reason, we suggest reading official documentation. 

### Installation

1. Clone the repo
```sh
git clone git@github.com:edaraiseh/CEN3031CivicProject.git
```

2. Move into the project directory
```sh
cd CEN3031CivicProject
```

3. Switch to the `backend` branch
```sh
git switch backend
```

4. Move into the backend directory
```sh
cd backend
```

5. Install all dotnet dependencies
```sh
dotnet restore
```

6. Create a file in backend/Api named `appsettings.Development.json`. This file will contain user secrets used for development, like a login and password for psql. Do not push this to the repo. Copy and paste the contents from `backend/Api/appsettings.json` into it and replace YOURUSERNAME and YOURPASSWORD.

7. Create the `tvdev` database
```sh
psql -U postgres # or a user account with access to database creation
CREATE DATABASE tvdev;
```

8. Apply all database migrations to the `tvdev` database
```
dotnet ef database update --project Api/Api.csproj
```

9. Compile the application
```sh
dotnet build TVBackend.sln
```

This should be sufficient for setup. Now, the application can be run using:
```sh
dotnet run --project Api/Api.csproj
```

And unit tests can be run using:
```sh
dotnet test TVBackend.sln
```

## BEST PRACTICES
Below is some best practices for committing to the backend. These will not necessarily be strictly enforced given the scope of this project, but it will make everything much easier if contributors stick to the guidelines. 

### Project Structure
```
backend/
  Api/
    Controllers/
    Data/
    Migrations/
    Models/
    Properties/
  Docs/
  Tests/
    ExampleTest.cs
  README.md
  TVBackend.sln
```

### Code Style
#### Naming Conventions
| Type | Convention | Example |
|------|------------|---------|
| Classes & Interfaces | PascalCase | `UserService`, `IUserRepository` |
| Methods | PascalCase | `GetUserById()` |
| Variables & fields | camelCase | `_dbContext`, `userService` |
| Async methods | Suffix `Async` | `LoginAsync()` |
| Constants | PascalCase | `DefaultTimeoutSeconds` |

#### Formatting & Comments
- 4 spaces per indent, lines ≤120 chars
- Use `var` only when type is obvious
- XML documentation for public classes/methods:
```csharp
/// <summary>
/// Retrieves a user by their ID.
/// </summary>
```

### API Design
#### REST Conventions
| Operation | Method | Example Endpoint |
|------|------------|---------|
| Create | POST | `/api/v1/users` |
| Read | GET | `/api/v1/users/{id}` |
| Update | PUT/PATCH | `/api/v1/users/{id}` |
| Delete | DELETE | `/api/v1/users/{id}` |

### Git Guidelines
#### Commit Style
- Keep commits small and frequent, each commit should have one singular focus
- Squash commits before raising a pull request to `backend`, pull requests must pass all tests and be code-reviewed (tentative, this might be too much of a pain for a project of this scope)
#### Branching Strategies
- All branches pertaining to backend developments should be prefixed with `<branch-type>/backend/`
- For example, a feature branch can be made as `feat/backend/feature-name`

### Testing Requirements
- Generally, a TDD approach should be followed, but given the limited scope of this project this will not be enforced
- Unit testing should be done using xUnit, integration testing should be done with xUnit and WebApplicationFactory
- Tests that require access to the database should use an in-memory database (Testcontainers for PSQL) that can be recreated every test run
- If external dependencies are needed, tests should use a mock instead
