using PizzaShop.Shared.Abstractions.DomainEvents;

namespace PizzaShop.Catalog.Domain.Toppings;

public sealed record ToppingUpdatedDomainEvent(Guid ToppingId) : IDomainEvent;
