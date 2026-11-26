# Reparteme

Aplicacion de inventario para gestionar la distribucion de productos (comida, bebidas, paquetes). Permite registrar productos, categorias y movimientos de entrada/salida con reporte de consumo.

## Stack

- **Backend:** ASP.NET Core Web API (.NET 10)
- **Base de datos:** PostgreSQL + Entity Framework Core
- **Frontend:** HTML + Tailwind CSS + JavaScript vanilla
- **Arquitectura:** Clean Architecture (3 capas)

## Estructura

- `Reparteme.Dominio` — entidades y reglas de negocio
- `Reparteme.Infraestructura` — acceso a datos (DbContext, repositorios)
- `Reparteme.Api` — controllers, servicios, DTOs y frontend (wwwroot)

## Configuracion

1. Clonar el repositorio
2. Copiar `.env.example` a `.env` y configurar la conexion a PostgreSQL
3. Ejecutar `dotnet run --project backend/Reparteme.Api`