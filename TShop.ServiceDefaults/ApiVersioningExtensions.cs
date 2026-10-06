using Asp.Versioning;
using Asp.Versioning.Builder;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace TShop.ServiceDefaults;

public static class ApiVersioningExtensions
{
    public static T AddSimpleStoreApiVersioning<T>(this T builder) where T : IHostApplicationBuilder
    {
        builder.Services
            .AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
            })
            .AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
        
        return builder;
    }
    
    public static RouteGroupBuilder MapApiV1Group(this IEndpointRouteBuilder app, string serviceSegment)
    {
        ArgumentException.ThrowIfNullOrEmpty(serviceSegment);

        var versionSet = app.NewApiVersionSet()
            .HasApiVersion(new ApiVersion(1, 0))
            .ReportApiVersions()
            .Build();

        return app
            .MapGroup($"/api/v{{version:apiVersion}}/{serviceSegment}")
            .WithApiVersionSet(versionSet)
            .MapToApiVersion(new ApiVersion(1, 0));
    }
}