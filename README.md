# 🧾 Event-Driven Order Processing System

> A production-style implementation of **Domain-Driven Design (DDD)** and **Clean Architecture** in **.NET 9**, showcasing event-driven order processing with commands, domain events, and aggregates.

![.NET](https://img.shields.io/badge/.NET-9.0-512BD4?style=flat-square&logo=dotnet)
![Architecture](https://img.shields.io/badge/Architecture-Clean%20Architecture-blue?style=flat-square)
![Pattern](https://img.shields.io/badge/Pattern-DDD-green?style=flat-square)
![Tests](https://img.shields.io/badge/Tests-9%20passing-brightgreen?style=flat-square)


---

## 📌 Overview

This project demonstrates how **commands**, **domain events**, and **aggregates** interact within a clean, layered architecture. It was built as a learning and portfolio reference for applying DDD principles in real-world .NET systems.

---

## 🏛️ Architecture

The system is structured around **Clean Architecture**, enforcing strict separation of concerns across four layers:
```

┌─────────────────────────────────┐
│        Presentation (Future)    │
├─────────────────────────────────┤
│        Application Layer        │  ← Commands, Handlers, Interfaces
├─────────────────────────────────┤
│          Domain Layer           │  ← Aggregates, Entities, Events, Value Objects
├─────────────────────────────────┤
│       Infrastructure Layer      │  ← Dispatcher, Publisher, Store, DI Wiring
└─────────────────────────────────┘
```

### Domain Layer
The heart of the system — contains all business logic and core domain concepts.

- **Aggregates** — enforce business rules and consistency boundaries
- **Entities** — objects with identity and lifecycle
- **Value Objects** — immutable, equality-by-value types
- **Domain Events** — side-effect triggers raised by aggregates
- **Enums** — strongly-typed domain state representations

### Application Layer
Orchestrates use cases without containing business logic.

- **Commands** — intent-expressing data objects
- **Command Handlers** — process commands and coordinate domain interactions
- **Interfaces** — abstractions consumed by the application layer

### Infrastructure Layer
Technical implementations that fulfill application and domain contracts.

- In-memory command dispatcher
- Domain event publisher
- In-memory order repository
- Dependency injection wiring

---

## 🔄 Order Processing Flow
```

Command
   ↓
Command Dispatcher
   ↓
Command Handler
   ↓
Order Aggregate
   ↓
Domain Event
   ↓
Event Publisher
```

### Example
```

ProcessPaymentCommand
   → Order.MarkPaymentCompleted()
   → PaymentProcessedEvent
   → EventPublisher
```

---

## 📁 Project Structure
```

OrderProcessing/
├── OrderProcessing.Domain/           # Core business logic
│   ├── Aggregates/
│   ├── Entities/
│   ├── Events/
│   └── ValueObjects/
│
├── OrderProcessing.Application/      # Use case coordination
│   ├── Commands/
│   ├── Handlers/
│   └── Interfaces/
│
├── OrderProcessing.Infrastructure/   # Technical implementations
│   ├── Dispatching/
│   ├── Publishing/
│   └── Persistence/
│
└── OrderProcessing.Domain.Tests/     # Unit tests for domain logic
```

---

## 🧪 Running Tests
```bash
dotnet test
```

**Latest test results:**

| Status    | Count |
|-----------|-------|
| ✅ Passed  | 8     |
| ⏭️ Skipped | 1     |
| ❌ Failed  | 0     |
| **Total** | **9** |

---

## 🛠️ Technologies

| Technology | Purpose |
|---|---|
| .NET 9 | Application framework |
| xUnit | Unit testing |
| Domain-Driven Design | Architectural pattern |
| Clean Architecture | Layering and separation of concerns |
| Event-Driven Architecture | Decoupled domain event handling |

---

## 🎯 Key Concepts Demonstrated

- ✅ **Aggregate design** — boundaries, invariants, and encapsulation
- ✅ **Command handling** — single-responsibility handlers per command
- ✅ **Domain events** — side-effect propagation without tight coupling
- ✅ **Clean architecture layering** — no domain/infrastructure leakage
- ✅ **Testable domain logic** — pure domain layer with no infrastructure dependencies



