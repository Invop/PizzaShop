using PizzaShop.Shared.Abstractions.DomainEvents;

namespace PizzaShop.Catalog.Domain.Categories;

public sealed record CategoryCreatedDomainEvent(Guid CategoryId) : IDomainEvent;
