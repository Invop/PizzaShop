namespace PizzaShop.Catalog.Domain.Preparations;

public static class PreparationErrors
{
    public static Error NotFound(Guid preparationId) => Error.NotFound(
        "Preparations.NotFound",
        $"The preparation with the Id = '{preparationId}' was not found.");

    public static Error AlreadyExists(string preparationName) => Error.Conflict(
        "Preparations.AlreadyExists",
        $"A preparation with the name '{preparationName}' already exists.");

    public static Error InvalidPreparation(Guid preparationId) => Error.Problem(
        "Preparations.InvalidPreparation",
        $"The preparation with Id = '{preparationId}' is invalid or does not exist.");
}
