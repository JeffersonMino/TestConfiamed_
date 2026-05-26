# Work Distribution System

Sistema de distribución inteligente de ítems de trabajo desarrollado con:

- ASP.NET Core
- SQL Server
- Entity Framework Core
- Arquitectura de Microservicios

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

## Tecnologías

- .NET 8
- SQL Server
- Swagger
- C#

## Reglas de negocio

- tareas urgentes:
  menos de 3 días
- tareas HIGH:
  prioridad alta
- usuarios saturados:
  más de 3 tareas HIGH

## Ejecución

1. Configurar SQL Server
2. Configurar appsettings.json
3. Ejecutar:
   dotnet run