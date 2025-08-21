IDistributedApplicationBuilder builder = DistributedApplication.CreateBuilder(args);
IResourceBuilder<RedisResource> redis = builder.AddRedis("redis");
IResourceBuilder<RabbitMQServerResource> rabbitMq = builder.AddRabbitMQ("eventbus")
    .WithLifetime(ContainerLifetime.Persistent);


await builder.Build().RunAsync().ConfigureAwait(false);
