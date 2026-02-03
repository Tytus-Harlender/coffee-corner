# CoffeeCorner – Online Coffee Shop (PoC)

*CoffeeCorner* is a proof-of-concept **monolithic e-commerce solution** for selling specialty coffee products online.<br> It is designed as a representative showcase of pragmatic, production-ready engineering practices using .NET and React.


### The business case:
*CoffeeCorner* is  a **small to mid-sized specialty coffee retailer** operating primarily in a direct-to-consumer (D2C) model but also including a B2B sales. The business focuses on online sales of coffee beans, ground coffee, and accessories, with optional wholesale.



**Annual turnover**: €2.5M – €4M

**Employees**: 15–25

**Orders per month**: 2,500–3,500 (up to ~8,000 during peak seasons)

**Average order value**: €35–€45

**Markets**: 1–2 countries

### Why this approach for the above business case?

- **Modular monolith** minimizes operational complexity while remaining easy to evolve

- **Domain-Driven Design** keeps core business logic explicit and protected

- **Clean Architecture** ensures separation of concerns and long-term maintainability

 - **CQRS with MediatR** (Vertical Slice Architecture) balances clarity and simplicity

 - **EF Core + PostgreSQL** provides reliable transactional consistency at low cost

- **JWT authentication with ASP.NET Core Identity** covers common security needs

This solution aims to avoid premature microservices while remaining ready for future extraction if scale demands it.
