namespace PizzaShop.ServiceDefaults;
public static class ApiEndpoints
{
    public const string ApiBase = "api/v{version:apiVersion}";

    public static class Catalog
    {
        public const string Base = $"{ApiBase}/catalog";
        public static class Items
        {
            public const string Base = $"{Catalog.Base}/items";

            public const string Create = Base;
            public const string Get = $"{Base}/{{idOrSlug}}";
            public const string GetAll = Base;
            public const string Update = $"{Base}/{{id:guid}}";
            public const string Delete = $"{Base}/{{id:guid}}";
        }

        public static class Categories
        {
            public const string Base = $"{Catalog.Base}/categories";

            public const string Create = Base;
            public const string Get = $"{Base}/{{idOrSlug}}";
            public const string GetAll = Base;
            public const string Update = $"{Base}/{{id:guid}}";
            public const string Delete = $"{Base}/{{id:guid}}";
        }

        public static class Toppings
        {
            public const string Base = $"{Catalog.Base}/toppings";

            public const string Create = Base;
            public const string Get = $"{Base}/{{id:guid}}";
            public const string GetAll = Base;
            public const string Update = $"{Base}/{{id:guid}}";
            public const string Delete = $"{Base}/{{id:guid}}";
        }

        public static class Preparations
        {
            public const string Base = $"{Catalog.Base}/preparations";

            public const string Create = Base;
            public const string Get = $"{Base}/{{id:guid}}";
            public const string GetAll = Base;
            public const string Update = $"{Base}/{{id:guid}}";
            public const string Delete = $"{Base}/{{id:guid}}";
        }

    }
}
