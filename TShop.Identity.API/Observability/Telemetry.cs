using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace TShop.Identity.API.Observability;

internal static class Telemetry
{
    public const string SourceName = "SimpleStore.Identity";

    public static readonly ActivitySource Source = new(SourceName);
    public static readonly Meter Meter = new(SourceName);
}