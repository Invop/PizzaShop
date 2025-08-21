namespace PizzaShop.Shared;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}
