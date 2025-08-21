namespace Microsoft.Extensions.DependencyInjection;

public interface IEventBusBuilder
{
    IServiceCollection Services { get; }
}
