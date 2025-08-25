using PizzaShop.Shared.Abstractions.DomainEvents;

namespace PizzaShop.Catalog.Domain.Items;
public sealed record ItemCreatedDomainEvent(Guid ItemId) : IDomainEvent;
