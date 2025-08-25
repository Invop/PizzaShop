using System.Reflection;

namespace ArchitectureTests.CatalogApi;

public abstract class BaseTest
{
    protected static readonly Assembly DomainAssembly = typeof(PizzaShop.Catalog.Domain.IAssemblyMarker).Assembly;
    protected static readonly Assembly ApplicationAssembly = typeof(PizzaShop.Catalog.Application.IAssemblyMarker).Assembly;
    protected static readonly Assembly InfrastructureAssembly = typeof(PizzaShop.Catalog.Infrastructure.IAssemblyMarker).Assembly;
    protected static readonly Assembly PresentationAssembly = typeof(PizzaShop.Catalog.Api.IAssemblyMarker).Assembly;

}
