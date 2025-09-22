# KeenVPN Architecture

## Layers

- **Core:** Domain models, interfaces, business logic
- **Infrastructure:** Data access, mock API, service implementations
- **Presentation:** WPF UI, viewmodels, state management

## Design Patterns

- **State Pattern:** Manages VPN connection status
- **Factory Pattern:** Service instantiation (if needed)

## SOLID Principles

- Single Responsibility: Each class has one responsibility
- Open/Closed: Services/interfaces are extendable
- Liskov Substitution: Interfaces allow for easy swapping
- Interface Segregation: Small, focused interfaces
- Dependency Inversion: UI depends on abstractions
