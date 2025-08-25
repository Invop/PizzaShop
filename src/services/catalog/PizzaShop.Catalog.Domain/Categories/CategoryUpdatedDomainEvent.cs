using PizzaShop.Shared.Abstractions.DomainEvents;

namespace PizzaShop.Catalog.Domain.Categories;

public sealed record CategoryUpdatedDomainEvent(Guid CategoryId) : IDomainEvent;
