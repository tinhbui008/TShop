using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace TShop.Identity.API.Client;

public class IdentityApiClientExtensions
{
    public static IHttpClientBuilder AddIdentityApiClient(
        IHostApplicationBuilder builder,
        string serviceName = "gateway")
    {
        return builder.Services.AddHttpClient<IIdentityApiClient, IdentityApiClient>(client =>
        {
            // "https+http://" lets Aspire prefer HTTPS and fall back to HTTP.
            client.BaseAddress = new Uri($"https+http://{serviceName}");
        });
    }
}