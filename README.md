# dotnet-efcore-boilerplate


## features

- **Layered architecture** — clear separation between domain, application and infrastructure
- **Generic Repository** — `IRepository<TEntity, TPrimaryKey>` with async CRUD and expression-based querying
- **Unit of Work** — transaction management via `IUnitOfWork`
- **JWT Authentication** — token generation and validation with configurable issuer/audience/secret
- **FluentValidation** — request DTO validation wired into the MVC pipeline
- **Swagger UI** — interactive API docs with Bearer token support