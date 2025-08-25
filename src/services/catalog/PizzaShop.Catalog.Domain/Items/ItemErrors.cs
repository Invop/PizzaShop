namespace PizzaShop.Catalog.Domain.Items;
public static class ItemErrors
{
    public static Error NotFound(Guid itemId) => Error.NotFound(
        "Items.NotFound",
        $"The item with the Id = '{itemId}' was not found.");


    public static Error NotFound(string slug) => Error.NotFound(
    "Items.NotFound",
    $"The item with the Slug = '{slug}' was not found.");

    public static Error InvalidSlug(string slug) => Error.Problem(
        "Items.InvalidSlug",
        $"The slug '{slug}' is invalid or does not match any existing item.");

    public static Error AlreadyExists(string itemName) => Error.Conflict(
        "Items.AlreadyExists",
        $"An item with the name '{itemName}' already exists.");

    public static Error InvalidCategory(Guid categoryId) => Error.Problem(
        "Items.InvalidCategory",
        $"The category with Id = '{categoryId}' is invalid or does not exist.");
}
