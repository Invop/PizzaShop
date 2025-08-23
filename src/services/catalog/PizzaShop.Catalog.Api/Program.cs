using PizzaShop.ServiceDefaults;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.AddServiceDefaults();
builder.AddDefaultOpenApi();

WebApplication app = builder.Build();


Asp.Versioning.Builder.IVersionedEndpointRouteBuilder vApi = app.NewVersionedApi("Catalog");
RouteGroupBuilder api = vApi.MapGroup($"{ApiEndpoints.Base}/catalog").HasDeprecatedApiVersion(1, 0).HasApiVersion(1, 1).HasApiVersion(2, 0);
RouteGroupBuilder v11 = vApi.MapGroup($"{ApiEndpoints.Base}/catalog").HasApiVersion(1, 1);
RouteGroupBuilder v1 = vApi.MapGroup($"{ApiEndpoints.Base}/catalog").HasDeprecatedApiVersion(1, 0);
RouteGroupBuilder v2 = vApi.MapGroup($"{ApiEndpoints.Base}/catalog").HasApiVersion(2, 0);

#pragma warning disable CA1861 // Avoid constant arrays as arguments
v1.MapGet("items", () => Results.Ok(new[] { "Item1 from v1", "Item2 from v1" }))
    .HasDeprecatedApiVersion(1, 0)
    .WithName("GetItemsV1")
    .WithOpenApi()
    .Produces<IEnumerable<string>>(StatusCodes.Status200OK);

v11.MapGet("items", () => Results.Ok(new[] { "Item1 from v1.1", "Item2 from v1.1" })).HasApiVersion(1, 1)
    .WithName("GetItemsV11")
    .WithOpenApi()
    .Produces<IEnumerable<string>>(StatusCodes.Status200OK);

v2.MapGet("items", () => Results.Ok(new[] { "Item1 from v2", "Item2 from v2" })).HasApiVersion(2, 0);

app.MapDefaultEndpoints();

app.UseHttpsRedirection();

app.UseDefaultOpenApi();
app.Run();
