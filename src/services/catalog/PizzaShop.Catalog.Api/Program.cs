using System.Reflection;
using PizzaShop.Catalog.Api.Endpoints;
using PizzaShop.Catalog.Api.Extensions;
using PizzaShop.Catalog.Api.Infrastructure;
using PizzaShop.ServiceDefaults;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults();

builder.Services.AddEndpoints(Assembly.GetExecutingAssembly());

builder.Services.AddEndpointsApiExplorer();
builder.AddDefaultOpenApi();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

WebApplication app = builder.Build();
app.CreateApiVersionSet();

app.MapDefaultEndpoints();
app.MapEndpoints();

app.UseHttpsRedirection();
app.UseExceptionHandler();
app.UseDefaultOpenApi();

app.Run();
