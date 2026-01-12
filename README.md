# CompartamosAppBackend (API)

API REST sencilla para demo bancaria (cuentas + transacciones).
Persistencia en memoria (EF Core InMemory) con datos seed para pruebas rápidas en Swagger.

## Tech
- .NET 8 (ASP.NET Core Web API)
- Entity Framework Core InMemory
- Swagger / OpenAPI

## Endpoints
- `GET /api/accounts/{id}` → retorna datos de la cuenta y balance
- `POST /api/transactions` → crea una transacción (DEPOSIT / WITHDRAW)

### Body ejemplo (POST /api/transactions)
```json
{
  "accountId": 1,
  "type": "DEPOSIT",
  "amount": 100
}
```

## Ejecutar
```bash
dotnet restore
dotnet run
```

## Swagger
- `/swagger`

## Notas
- La BD es InMemory: al reiniciar el backend, se reinician los datos.
- La cuenta seed principal suele ser `id = 1` (según tu `AppDbContext`).
