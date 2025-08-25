namespace PizzaShop.Catalog.Domain.Toppings;

public static class ToppingErrors
{
    public static Error NotFound(Guid toppingId) => Error.NotFound(
        "Toppings.NotFound",
        $"The topping with the Id = '{toppingId}' was not found.");

    public static Error AlreadyExists(string toppingName) => Error.Conflict(
        "Toppings.AlreadyExists",
        $"A topping with the name '{toppingName}' already exists.");

    public static Error InvalidTopping(Guid toppingId) => Error.Problem(
        "Toppings.InvalidTopping",
        $"The topping with Id = '{toppingId}' is invalid or does not exist.");
}
