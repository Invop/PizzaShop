using PizzaShop.Shared.Abstractions.DomainEvents;

namespace PizzaShop.Catalog.Domain.Toppings;

public sealed record ToppingDeletedDomainEvent(Guid ToppingId) : IDomainEvent;
