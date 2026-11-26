# Contribucion

## Ramas

- `main` — produccion
- `develop` — desarrollo
- `qa` — pruebas

## Flujo de trabajo

1. Crear rama `feature/nombre` desde `develop`
2. Hacer commits atomicos con prefijos
3. Push y crear 3 PRs: feature → develop, feature → qa, feature → main
4. Merge con "Create a merge commit"
5. No borrar ramas despues del merge

## Commits

Formato: `prefijo: mensaje en imperativo sin punto final`

Prefijos:
- `feat:` — nueva funcionalidad
- `fix:` — correccion de error
- `chore:` — tarea de configuracion o mantenimiento
- `refactor:` — reestructurar codigo sin cambiar funcionalidad
- `docs:` — documentacion
- `test:` — pruebas