using PizzaShop.EventBus.Events;

namespace PizzaShop.EventBus.Abstractions;

public interface IEventBus
{
    Task PublishAsync(IntegrationEvent @event);
}
