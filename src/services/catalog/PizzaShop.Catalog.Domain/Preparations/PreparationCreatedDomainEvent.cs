using PizzaShop.Shared.Abstractions.DomainEvents;

namespace PizzaShop.Catalog.Domain.Preparations;
public sealed record PreparationCreatedDomainEvent(Guid PreparationId) : IDomainEvent;
