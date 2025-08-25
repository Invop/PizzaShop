namespace PizzaShop.Catalog.Domain.Categories;
public static class CategoryErrors
{
    public static Error NotFound(string idOrSlug) => Error.NotFound(
        "Categories.NotFound",
        $"The category with the Id or Slug = '{idOrSlug}' was not found.");

    public static Error AlreadyExists(string categoryName) => Error.Conflict(
        "Categories.AlreadyExists",
        $"A category with the name '{categoryName}' already exists.");

    public static Error InvalidParentCategory(Guid parentCategoryId) => Error.Problem(
        "Categories.InvalidParentCategory",
        $"The parent category with Id = '{parentCategoryId}' is invalid or does not exist.");
}
