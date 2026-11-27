# Reparteme

Sistema de inventario para gestionar la distribucion de productos. Permite registrar categorias, productos y movimientos de entrada/salida con reporte de consumo en tiempo real.


## Stack Tecnologico

- **Backend:** ASP.NET Core Web API (.NET 10)
- **Base de datos:** SQLite + Entity Framework Core
- **Frontend:** HTML + Tailwind CSS + JavaScript vanilla
- **Arquitectura:** Clean Architecture (3 capas)



## Estructura del proyecto

```
backend/
  Reparteme.Dominio/         → Entidades, enums e interfaces
  Reparteme.infraestructura/ → DbContext, repositorios y seed de datos
  Reparteme.Api/             → Controllers, DTOs y frontend (wwwroot)
    wwwroot/
      index.html             → Pagina principal
      categorias.html        → CRUD de categorias
      productos.html         → CRUD de productos
      movimientos.html       → Registro de entradas y salidas
      reporte.html           → Reporte de consumo
      css/styles.css         → Estilos personalizados
      js/                    → Logica del frontend separada por modulo
      img/                   → Logo e imagenes
```




## Arquitectura

El proyecto sigue el patron de **Clean Architecture** dividido en 3 capas:

| Capa | Proyecto | Responsabilidad |
|------|----------|-----------------|
| Dominio | `Reparteme.Dominio` | Entidades (`Categoria`, `Producto`, `MovimientoInventario`), enums (`TipoMovimiento`) e interfaces de repositorio |
| Infraestructura | `Reparteme.infraestructura` | Implementacion de repositorios, `AppDbContext`, configuraciones de EF Core y seed de datos iniciales |
| API | `Reparteme.Api` | Controllers REST, DTOs de request/response, `Program.cs` y frontend estatico en `wwwroot/` |

La comunicacion entre capas es unidireccional: **API → Infraestructura → Dominio**. El dominio no depende de ninguna otra capa.





## Requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download)

## Como ejecutar

1. Clonar el repositorio:
   ```bash
   git clone https://github.com/StephReynosoDev/reparteme.git
   cd reparteme
   ```

2. Ir a la carpeta del proyecto API:
   ```bash
   cd backend/Reparteme.Api
   ```

3. Ejecutar la aplicacion:
   ```bash
   dotnet run
   ```

4. Abrir en el navegador:
   ```
   http://localhost:5119
   ```

No requiere configuracion adicional. La base de datos SQLite se crea automaticamente al iniciar y el seed agrega categorias y productos de ejemplo si la base esta vacia.

## Funcionalidades

### Categorias
- Crear, editar y eliminar categorias
- Buscar categorias por nombre
- Estado activa/inactiva con indicador visual


### Productos
- Crear, editar y eliminar productos
- Buscar productos por nombre
- Foto del producto mediante URL
- Validacion de nombres duplicados
- Asociacion a categoria


### Movimientos de Inventario
- Registrar entradas y salidas de productos
- Validacion de stock: no permite salidas mayores al stock disponible
- Validacion de cantidad: solo valores entre 1 y 999,999
- Historial con fecha y hora de cada movimiento


### Reporte de Consumo
- Vista general de todos los productos
- Total de entradas y salidas por producto
- Stock actual con indicador visual de stock negativo


### Manejo de Errores
- Notificaciones toast de exito (verde) y error (rojo)
- Modal de confirmacion personalizado para eliminaciones
- Validaciones en frontend y backend


## Endpoints de la API

| Metodo | Ruta | Descripcion |
|--------|------|-------------|
| GET | `/api/categorias` | Listar todas las categorias |
| POST | `/api/categorias` | Crear categoria |
| PUT | `/api/categorias/{id}` | Actualizar categoria |
| DELETE | `/api/categorias/{id}` | Eliminar categoria |
| GET | `/api/productos` | Listar todos los productos |
| POST | `/api/productos` | Crear producto |
| PUT | `/api/productos/{id}` | Actualizar producto |
| DELETE | `/api/productos/{id}` | Eliminar producto |
| GET | `/api/movimientos` | Listar todos los movimientos |
| POST | `/api/movimientos` | Registrar movimiento |
| GET | `/api/reporte/consumo` | Obtener reporte de consumo |


## Git Flow

Este proyecto utiliza la metodologia **Git Flow** para el control de versiones:


### Ramas principales
- `main` → Codigo en produccion, estable y listo para entregar
- `qa` → Rama de pruebas y control de calidad
- `develop` → Rama de desarrollo donde se integran las features


### Ramas de funcionalidades
Cada funcionalidad se desarrollo en su propia rama `feature/` y se integro mediante Pull Requests:


| Rama | Descripcion |
|------|-------------|
| `feature/estructura-inicial` | Estructura del proyecto, entidades y DbContext |
| `feature/crud-categorias` | CRUD completo de categorias |
| `feature/crud-productos` | CRUD completo de productos |
| `feature/movimientos-reporte` | Movimientos de inventario y reporte de consumo |
| `feature/correccion-errores` | Rediseno del frontend, validaciones y manejo de errores |


### Flujo de integracion
Cada feature branch se integro mediante **3 Pull Requests independientes**:
1. `feature/*` → `develop` (integracion al desarrollo)
2. `feature/*` → `qa` (pasa a pruebas)
3. `feature/*` → `main` (sube a produccion)


Todos los merges se realizaron con **merge commit** (sin squash ni rebase) para mantener el historial completo de commits.

Las ramas de feature **no se eliminan** despues del merge para mantener la trazabilidad del desarrollo.


## Autor

**Stephen Reynoso** — Estudiante de Desarrollo de Software, ITLA
- GitHub: [@StephReynosoDev](https://github.com/StephReynosoDev)