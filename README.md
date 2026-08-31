# api.restaurante — Orion

API de negócio do **Orion** (Restaurante). .NET 8, camadas:

```
src/
  Orion.API            → HTTP, JWT, controllers
  Orion.Application    → casos de uso / contratos
  Orion.Infrastructure → EF Core (schema `orion`), accessor do usuário
  Orion.Core           → claims Enterprise, códigos de módulo
```

Não duplica `usuarios`. O JWT é o **mesmo** emitido pelo oAuth (via Gateway).

## Integração Enterprise

| Peça | Valor |
|------|--------|
| Sistema (`core.sistemas.codigo`) | `ORI` |
| Módulo raiz | `ORI0000000` |
| Gateway | `/api/restaurante/**` |
| Eureka / service id | `restaurante` |
| Porta local | `8091` |
| Schema Postgres | `orion` |

Front: `app.restaurante` → só chama `http://localhost:8080` (Gateway) + `X-Secret-Token` + Bearer.

## Pré-requisitos

- .NET 8 SDK
- Gateway + oAuth + Core no ar
- Seed: `infra/seed-sistema.sql` (neste repo)
- `JWT_SECRET` **igual** ao oAuth/Gateway

## Rodar local

```bash
# na pasta api.restaurante
dotnet restore
dotnet run --project src/Orion.API
# http://localhost:8091/health
# Swagger: http://localhost:8091/swagger
```

Gateway local (sem Eureka) precisa de:

```
GATEWAY_RESTAURANTE_URI=http://localhost:8091
```

Smoke (depois do login no front):

```http
GET http://localhost:8080/api/restaurante/me
Authorization: Bearer <access_token>
X-Secret-Token: <FRONTEND_SECRET_TOKEN>
```

Sem o módulo `ORI0000000` no JWT → **403**.

## O que NÃO fazer

- Novo login / tabela de usuários
- Chamar Core `:8081` do browser
- Inventar códigos de módulo fora de `ORI*`
