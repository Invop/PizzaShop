namespace PizzaShop.Shared.Abstractions;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}
