using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PizzaShop.Shared.Abstractions.DomainEvents;
using PizzaShop.Shared.Abstractions.Messaging;
namespace PizzaShop.Catalog.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.Scan(scan => scan.FromAssembliesOf(typeof(IAssemblyMarker))
            .AddClasses(classes => classes.AssignableTo(typeof(IQueryHandler<,>)), publicOnly: false)
                .AsImplementedInterfaces()
                .WithScopedLifetime()
            .AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<>)), publicOnly: false)
                .AsImplementedInterfaces()
                .WithScopedLifetime()
            .AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<,>)), publicOnly: false)
                .AsImplementedInterfaces()
                .WithScopedLifetime());

        //TODO: DECORATORS?

        services.Scan(scan => scan.FromAssembliesOf(typeof(IAssemblyMarker))
            .AddClasses(classes => classes.AssignableTo(typeof(IDomainEventHandler<>)), publicOnly: false)
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        services.AddValidatorsFromAssembly(typeof(IAssemblyMarker).Assembly, includeInternalTypes: true);

        return services;
    }
}
