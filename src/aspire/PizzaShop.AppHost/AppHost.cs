IDistributedApplicationBuilder builder = DistributedApplication.CreateBuilder(args);
IResourceBuilder<RedisResource> redis = builder.AddRedis("redis");
IResourceBuilder<RabbitMQServerResource> rabbitMq = builder.AddRabbitMQ("eventbus")
    .WithLifetime(ContainerLifetime.Persistent);


builder.AddProject<Projects.PizzaShop_Catalog_Api>("pizzashop-catalog-api");


await builder.Build().RunAsync().ConfigureAwait(false);
