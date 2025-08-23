using System.Text;
using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;
using Microsoft.OpenApi.Models;

namespace PizzaShop.ServiceDefaults;

internal static class OpenApiOptionsExtensions
{
    public static OpenApiOptions ApplyApiVersionInfo(this OpenApiOptions options, string title, string description)
    {
        options.AddDocumentTransformer((document, context, cancellationToken) =>
        {
            IApiVersionDescriptionProvider? versionedDescriptionProvider = context.ApplicationServices.GetService<IApiVersionDescriptionProvider>();
            ApiVersionDescription? apiDescription = versionedDescriptionProvider?.ApiVersionDescriptions
                .SingleOrDefault(description => description.GroupName == context.DocumentName);
            if (apiDescription is null)
            {
                return Task.CompletedTask;
            }
            document.Info.Version = apiDescription.ApiVersion.ToString();
            document.Info.Title = title;
            document.Info.Description = BuildDescription(apiDescription, description);
            return Task.CompletedTask;
        });
        return options;
    }

    private static string BuildDescription(ApiVersionDescription api, string description)
    {
        var text = new StringBuilder(description);

        if (api.IsDeprecated)
        {
            AppendDeprecatedNotice(text);
        }

        if (api.SunsetPolicy is { } policy)
        {
            AppendSunsetPolicy(text, policy);
        }

        return text.ToString();
    }

    private static void AppendDeprecatedNotice(StringBuilder text)
    {
        if (text.Length > 0 && text[^1] != '.')
        {
            text.Append('.');
        }

        text.Append(" This API version has been deprecated.");
    }

    private static void AppendSunsetPolicy(StringBuilder text, SunsetPolicy policy)
    {
        if (policy.Date is { } when)
        {
            text.Append(" The API will be sunset on ")
                .Append(when.Date.ToShortDateString())
                .Append('.');
        }

        if (policy.HasLinks)
        {
            text.AppendLine();
            text.Append("<h4>Links</h4><ul>");

            foreach (LinkHeaderValue? link in policy.Links.Where(l => l.Type == "text/html"))
            {
                text.Append("<li><a href=\"")
                    .Append(link.LinkTarget.OriginalString)
                    .Append("\">")
                    .Append(StringSegment.IsNullOrEmpty(link.Title) ? link.LinkTarget.OriginalString : link.Title.ToString())
                    .Append("</a></li>");
            }

            text.Append("</ul>");
        }
    }

    public static OpenApiOptions ApplyOperationDeprecatedStatus(this OpenApiOptions options)
    {
        options.AddOperationTransformer((operation, context, cancellationToken) =>
        {
            operation.Deprecated |= context.Description.IsDeprecated();
            return Task.CompletedTask;
        });
        return options;
    }

    public static OpenApiOptions ApplySchemaNullableFalse(this OpenApiOptions options)
    {
        options.AddSchemaTransformer((schema, context, cancellationToken) =>
        {
            if (schema.Properties is not null)
            {
                foreach (KeyValuePair<string, OpenApiSchema> property in schema.Properties)
                {
                    bool isRequired = schema.Required?.Contains(property.Key) ?? false;
                    if (!isRequired)
                    {
                        property.Value.Nullable = false;
                    }
                }
            }

            return Task.CompletedTask;
        });
        return options;
    }
}
