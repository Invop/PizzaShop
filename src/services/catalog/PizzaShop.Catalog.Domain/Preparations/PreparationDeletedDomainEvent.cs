using PizzaShop.Shared.Abstractions.DomainEvents;

namespace PizzaShop.Catalog.Domain.Preparations;

public sealed record PreparationDeletedDomainEvent(Guid PreparationId) : IDomainEvent;
