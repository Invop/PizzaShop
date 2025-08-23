using Asp.Versioning;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Scalar.AspNetCore;

namespace PizzaShop.ServiceDefaults;

public static partial class Extensions
{
    public static IApplicationBuilder UseDefaultOpenApi(this WebApplication app)
    {
        IConfiguration configuration = app.Configuration;
        IConfigurationSection openApiSection = configuration.GetSection("OpenApi");
        // Extract API versions dynamically from configuration
        string[] apiVersions = openApiSection.GetSection("Versions").Get<string[]>() ?? ["v1"];
        if (!openApiSection.Exists())
        {
            return app;
        }

        app.MapOpenApi();

        if (app.Environment.IsDevelopment())
        {
            app.MapScalarApiReference(options =>
            {
                // Disable default fonts to avoid download unnecessary fonts
                options.DefaultFonts = false;
                options.AddDocuments(apiVersions);
            });
            app.MapGet("/", () => Results.Redirect("/scalar")).ExcludeFromDescription();
        }

        return app;
    }

    public static IHostApplicationBuilder AddDefaultOpenApi(
        this IHostApplicationBuilder builder)
    {

        builder.Services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.AssumeDefaultVersionWhenUnspecified = true;

            // Чтение версии ТОЛЬКО из URL
            options.ApiVersionReader = new UrlSegmentApiVersionReader();
        }).AddApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        });
        IConfigurationSection openApi = builder.Configuration.GetSection("OpenApi");

        if (!openApi.Exists())
        {
            return builder;
        }
        // Read document names from configuration, e.g. OpenApi:Versions = ["v1","v2","v3"]
        string[] versions = openApi.GetSection("Versions").Get<string[]>() ?? ["v1"];

        foreach (string description in versions)
        {
            builder.Services.AddOpenApi(description, options =>
            {
                options.ApplyApiVersionInfo(openApi.GetRequiredValue("Document:Title"), openApi.GetRequiredValue("Document:Description"));
                options.ApplyOperationDeprecatedStatus();
                options.ApplySchemaNullableFalse();
                // Clear out the default servers so we can fallback to
                // whatever ports have been allocated for the service by Aspire
                options.AddDocumentTransformer((document, context, cancellationToken) =>
                {
                    document.Servers = [];
                    return Task.CompletedTask;
                });
            });
        }


        return builder;
    }
}
