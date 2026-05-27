# MricoDistribusion

Sistema de distribución inteligente de ítems de trabajo desarrollado con:

- ASP.NET Core
- SQL Server
- Entity Framework Core
- Arquitectura de Microservicios


## Architecture

The solution uses a microservices architecture:

- Items.Microservice
- UserManagement.Microservice

## Layers

- Controllers
- Services
- Repositories
- DTOs
- Models
- Data

## Microservicios

### Items.Microservice
Gestiona:
- creación de tareas
- asignación automática
- prioridades
- fechas de entrega

### UserManagement.Microservice
Gestiona:
- usuarios
- estadísticas
- carga laboral

## Reglas de negocio

- tareas urgentes:
  menos de 3 días
- tareas HIGH:
  prioridad alta
- usuarios saturados:
  más de 3 tareas HIGH

## Tecnologías

- ASP.NET Core
- SQL Server
- Entity Framework Core
- Swagger

## Ejecución

1. Configure SQL Server
2. Update appsettings.json
3. Execute:

dotnet restore
dotnet build
dotnet run